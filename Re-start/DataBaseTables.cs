using System;
using System.Data;
using System.Data.SqlClient;
using LibraryForSQLCon;

namespace Re_start
{
    class DataBaseTables
    {
        Registry_Class registry = new Registry_Class();
        public SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
        public event Action<DataTable> dtFillFull;

        //Переменная для прослушивания
        public SqlDependency dependency = new SqlDependency();

        //Таблицы
        public DataTable dtChek = new DataTable("Chek");
        public DataTable dtContracts = new DataTable("Contracts");
        public DataTable dtDan_Check = new DataTable("Dan_Check");
        public DataTable dtDetails = new DataTable("Details");
        public DataTable dtDolj = new DataTable("Dolj");
        public DataTable dtGarant = new DataTable("Garant");
        public DataTable dtIsp_srok = new DataTable("Isp_srok");
        public DataTable dtKlient = new DataTable("Klient");
        public DataTable dtModel_Device = new DataTable("Model_Device");
        public DataTable dtOtdel = new DataTable("Otdel");
        public DataTable dtPrihod_Details = new DataTable("Prihod_Details");
        public DataTable dtProizvod_Device = new DataTable("Proizvod_Device");
        public DataTable dtRepairs = new DataTable("Repairs");
        public DataTable dtRole = new DataTable("Role");
        public DataTable dtServices = new DataTable("Services");
        public DataTable dtSklad = new DataTable("Sklad");
        public DataTable dtSotr = new DataTable("Sotr");
        public DataTable dtStore_Basket = new DataTable("Store_Basket");
        public DataTable dtTests = new DataTable("Tests");
        public DataTable dtType_Device = new DataTable("Type_Device");
        public DataTable dtCHANGES_LOG = new DataTable("CHANGES_LOG");

        //Запросы
        public string qrChek = "SELECT ID_Chek, dbo.Chek.Num_Check, dbo.Chek.Data_Prod, dbo.Chek.Time_Prod, dbo.Chek.Data_Prod + ' ' + dbo.Chek.Time_Prod FROM dbo.Chek where Chek_logical_Delete = 0",
            qrContracts = "SELECT dbo.Contracts.ID_Contr, dbo.Contracts.Num_Contr, dbo.Contracts.Login_Kl, dbo.Klient.Login_Kl, dbo.Klient.Familiya + ' ' + dbo.Klient.Imya + ' ' + dbo.Klient.Otchestvo, dbo.Contracts.Model_ID, dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model, dbo.Model_Device.Model_Photo, dbo.Contracts.Login_St, dbo.Sotr.Login_St, dbo.Sotr.Familiya + ' ' + dbo.Sotr.Imya + ' ' + dbo.Sotr.Otchestvo, dbo.Contracts.Treshchiny, dbo.Contracts.Tsarapiny, dbo.Contracts.Rabotosposobnost, dbo.Contracts.Comment FROM   dbo.Contracts JOIN dbo.Klient ON dbo.Contracts.Login_Kl = dbo.Klient.Login_Kl JOIN dbo.Sotr ON dbo.Contracts.Login_St = dbo.Sotr.Login_St JOIN dbo.Model_Device ON dbo.Contracts.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrDan_Check = "SELECT dbo.Dan_Check.ID_Dan_Chek, dbo.Dan_Check.Chek_ID, dbo.Chek.ID_Chek, dbo.Dan_Check.Repairs_ID, dbo.Repairs.ID_Repairs, Contr_ID, dbo.Contracts.Num_Contr, dbo.Dan_Check.Stoimost FROM   dbo.Dan_Check JOIN dbo.Repairs ON dbo.Dan_Check.Repairs_ID = dbo.Repairs.ID_Repairs JOIN dbo.Chek ON dbo.Dan_Check.Chek_ID = dbo.Chek.ID_Chek JOIN dbo.Contracts ON dbo.Repairs.Contr_ID = dbo.Contracts.ID_Contr",
            qrDetails = "SELECT dbo.Details.ID_Details, dbo.Details.Naim_Details, dbo.Details.Garant_ID, dbo.Garant.ID_Garant, dbo.Garant.Dlitelnost, dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model as 'Модели', dbo.Details.Naim_Details + ' для ' + dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model as 'Деталь', dbo.Details.Model_ID FROM dbo.Details JOIN dbo.Garant ON dbo.Details.Garant_ID = dbo.Garant.ID_Garant JOIN dbo.Model_Device ON dbo.Details.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrDolj = "SELECT dbo.Dolj.ID_Dolj, dbo.Dolj.Otdel_ID, dbo.Otdel.ID_Otdel, dbo.Otdel.Naim_Otdela, dbo.Dolj.Naim_Dolj, dbo.Dolj.Oklad, Dney_Na_Isp_Srok FROM dbo.Dolj JOIN dbo.Otdel ON dbo.Dolj.Otdel_ID = dbo.Otdel.ID_Otdel",
            qrGarant = "SELECT ID_Garant, Dlitelnost FROM dbo.Garant",
            qrIsp_srok = "SELECT dbo.Isp_srok.ID_Isp, dbo.Isp_srok.Login_St, dbo.Sotr.Login_St, dbo.Sotr.Familiya + ' ' + dbo.Sotr.Imya + ' ' + dbo.Sotr.Otchestvo, dbo.Isp_srok.Data_Start, dbo.Isp_srok.Data_End FROM dbo.Isp_srok JOIN dbo.Sotr ON dbo.Isp_srok.Login_St = dbo.Sotr.Login_St",
            qrKlient = "SELECT Login_Kl, Familiya, Imya, Otchestvo, Familiya + ' ' + Imya + ' ' + Otchestvo + ' (' + Login_Kl + ')' as 'Клиент', Data_Rojd FROM dbo.Klient",
            qrModel_Device = "SELECT ID_Model, dbo.Type_Device.Naim_type + ' '+ dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model as 'Модели', dbo.Model_Device.Proizvod_ID, ID_Proizvod, dbo.Model_Device.Naim_Model FROM dbo.Model_Device JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrOtdel = "SELECT ID_Otdel, Naim_Otdela, Count_Chel FROM dbo.Otdel",
            qrPrihod_Details = "SELECT dbo.Prihod_Details.ID_Prihod, dbo.Prihod_Details.Details_ID, dbo.Details.ID_Details, dbo.Details.Naim_Details + ' для ' + dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model, dbo.Prihod_Details.Count_Prih, dbo.Prihod_Details.Data_Prih FROM dbo.Prihod_Details JOIN dbo.Details ON dbo.Prihod_Details.Details_ID = dbo.Details.ID_Details JOIN dbo.Model_Device ON dbo.Details.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrProizvod_Device = "SELECT dbo.Proizvod_Device.ID_Proizvod, dbo.Proizvod_Device.Naim_Proizvod, dbo.Proizvod_Device.Type_ID, dbo.Type_Device.ID_Type, dbo.Type_Device.Naim_type, dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod FROM dbo.Proizvod_Device JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrRepairs = "SELECT dbo.Repairs.ID_Repairs, dbo.Repairs.Contr_ID, dbo.Contracts.ID_Contr, dbo.Contracts.Num_Contr, dbo.Repairs.Date_Start, dbo.Repairs.Date_End, dbo.Repairs.Status, dbo.Repairs.Services_ID, dbo.Services.ID_Services, dbo.Services.Naim_Services FROM dbo.Repairs JOIN dbo.Contracts ON dbo.Repairs.Contr_ID = dbo.Contracts.ID_Contr JOIN dbo.Services ON dbo.Repairs.Services_ID = dbo.Services.ID_Services",
            qrRole = "SELECT ID_Role, Naim_Role, Roles, Profiles, Yslugi, Dogovora, Klients, Remonti, Statusi, Prihodi, Sklad, Lich_Dela, Doljnosti, Otdeli, Detali, Tipi_Ystr, Proizvodit_Yastr, Modeli_Ystr, Testirovaniya, Isp_sroki, Cheki FROM dbo.Role",
            qrServices = "SELECT dbo.Services.ID_Services, dbo.Services.Naim_Services, dbo.Services.Stoimost_Serv, dbo.Services.Dlitelnost, dbo.Services.Details_ID, dbo.Details.ID_Details, dbo.Services.Naim_Services + ' ' + ' для ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model as 'Услуга'  FROM dbo.Proizvod_Device JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type JOIN dbo.Model_Device ON dbo.Proizvod_Device.ID_Proizvod = dbo.Model_Device.Proizvod_ID JOIN dbo.Services JOIN dbo.Details ON dbo.Services.Details_ID = dbo.Details.ID_Details ON dbo.Model_Device.ID_Model = dbo.Details.Model_ID",
            qrSklad = "SELECT dbo.Sklad.ID_Sklad, dbo.Sklad.Details_ID, dbo.Details.ID_Details, dbo.Details.Naim_Details + ' для ' + dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model as 'Деталь', Convert(varchar(10), dbo.Sklad.Count_Det) + ' шт.', dbo.Sklad.Count_Det FROM dbo.Sklad JOIN dbo.Details ON dbo.Sklad.Details_ID = dbo.Details.ID_Details JOIN dbo.Model_Device ON dbo.Details.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrSotr = "SELECT Login_St, dbo.Sotr.Num_Lich_Dela, dbo.Sotr.Familiya, dbo.Sotr.Imya, dbo.Sotr.Otchestvo, dbo.Sotr.Familiya + ' ' + dbo.Sotr.Imya + ' ' + dbo.Sotr.Otchestvo + ' (' + dbo.Dolj.Naim_Dolj + ')' as 'Сотрудник', dbo.Sotr.DateOfRojd, dbo.Sotr.S_Pas, dbo.Sotr.N_Pas, Convert(varchar(4),dbo.Sotr.S_Pas) + ' ' + Convert(varchar(6),dbo.Sotr.N_Pas), dbo.Sotr.Adres_Proj, dbo.Sotr.Dolj_ID, dbo.Dolj.ID_Dolj, dbo.Dolj.Naim_Dolj, dbo.Profile.Profile_Photo FROM dbo.Sotr JOIN dbo.Dolj ON dbo.Sotr.Dolj_ID = dbo.Dolj.ID_Dolj JOIN dbo.Profile ON dbo.Sotr.Login_St = dbo.Profile.Login",
            qrStore_Basket = "SELECT dbo.Store_Basket.ID_Store_Basket, dbo.Store_Basket.Login_Klt, dbo.Services.ID_Services, dbo.Services.Naim_Services + ' (' + dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model  + ')'  FROM dbo.Store_Basket JOIN dbo.Klient ON dbo.Store_Basket.Login_Klt = dbo.Klient.Login_Kl JOIN dbo.Services ON dbo.Store_Basket.Services_ID = dbo.Services.ID_Services JOIN dbo.Details ON dbo.Services.Details_ID = dbo.Details.ID_Details JOIN dbo.Model_Device ON dbo.Details.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type",
            qrTests = "SELECT dbo.Tests.ID_Test, dbo.Tests.Contr_ID, dbo.Contracts.ID_Contr, dbo.Contracts.Num_Contr, dbo.Tests.Zaversh FROM dbo.Tests JOIN dbo.Contracts ON dbo.Tests.Contr_ID = dbo.Contracts.ID_Contr",
            qrType_Device = "SELECT ID_Type, Naim_type FROM dbo.Type_Device",
            qrCHANGES_LOG = "SELECT CHANGE_ID, CHANGE_DATE, CHANGE_TYPE, DANNIE FROM dbo.CHANGES_LOG";

        private void dtFill(DataTable table, string query)
        {
            try
            {
                command.Notification = null;
                //в команду записываем запрос
                command.CommandText = query;
                //Открытие подключения
                Registry_Class.sqlConnection.Open();
                //Выполнение команды
                dependency.AddCommandDependency(command);
                //Прослушивание
                SqlDependency.Start(Registry_Class.sqlConnection.ConnectionString);

                table.Load(command.ExecuteReader());
            }
            catch (StackOverflowException ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + ex.Message;
            }
            finally
            {
                //Закрытие подключения
                Registry_Class.sqlConnection.Close();
            }
        }

        public void dtChekFill()
        {
            //Вызов метода с указаниев таблицы и запроса
            dtFill(dtChek, qrChek);
        }

        public void dtCHANGES_LOGFill()
        {
            dtFill(dtCHANGES_LOG, qrCHANGES_LOG);
        }

        public void dtContractsFill()
        {
            dtFill(dtContracts, qrContracts);
        }

        public void dtDan_CheckFill()
        {
            dtFill(dtDan_Check, qrDan_Check);
        }

        public void dtDetailsFill()
        {
            dtFill(dtDetails, qrDetails);
        }

        public void dtDoljFill()
        {
            dtFill(dtDolj, qrDolj);
        }

        public void dtGarantFill()
        {
            dtFill(dtGarant, qrGarant);
        }

        public void dtIsp_srokFill()
        {
            dtFill(dtIsp_srok, qrIsp_srok);
        }

        public void dtKlientsFill()
        {
            dtFill(dtKlient, qrKlient);
        }

        public void dtModel_DeviceFill()
        {
            dtFill(dtModel_Device, qrModel_Device);
        }

        public void dtOtdelFill()
        {
            dtFill(dtOtdel, qrOtdel);
        }

        public void dtPrihod_DetailsFill()
        {
            dtFill(dtPrihod_Details, qrPrihod_Details);
        }

        public void dtProizvod_DeviceFill()
        {
            dtFill(dtProizvod_Device, qrProizvod_Device);
        }

        public void dtRepairsFill()
        {
            dtFill(dtRepairs, qrRepairs);
        }

        public void dtRoleFill()
        {
            dtFill(dtRole, qrRole);
        }

        public void dtServicesFill()
        {
            dtFill(dtServices, qrServices);
        }

        public void dtSkladFill()
        {
            dtFill(dtSklad, qrSklad);
        }

        public void dtSotrFill()
        {
            dtFill(dtSotr, qrSotr);
        }

        public void dtStore_BasketFill()
        {
            dtFill(dtStore_Basket, qrStore_Basket);
        }

        public void dtTestsFill()
        {
            dtFill(dtTests, qrTests);
        }

        public void dtType_DeviceFill()
        {
            dtFill(dtType_Device, qrType_Device);
        }

    }
}