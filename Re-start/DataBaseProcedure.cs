using LibraryForSQLCon;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Re_start
{
    class DataBaseProcedure
    {
        private void message(object sender, SqlInfoMessageEventArgs e)
        {
            Registry_Class.error_message += "\n" + DateTime.Now.ToLongDateString() + " " + e.Message;
        }

        private SqlCommand cmd = new SqlCommand("Empty", Registry_Class.sqlConnection);
        private void spConfiguration(string spName)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = spName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public void spADD_Garant(string Dlitelnost)
        {
            //Наименование процедуры
            spConfiguration("ADD_Garant");
            try
            {
                //Параметры
                cmd.Parameters.AddWithValue("@Dlitelnost", Dlitelnost);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Garant(int ID_Garant, string Dlitelnost)
        {
            spConfiguration("Upd_Garant");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Garant", ID_Garant);
                cmd.Parameters.AddWithValue("@Dlitelnost", Dlitelnost);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Garant(int ID_Garant)
        {
            spConfiguration("Del_Garant");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Garant", ID_Garant);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spLogical_Delete_Garant(int ID_Garant)
        {
            spConfiguration("Logical_Delete_Garant");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Garant", ID_Garant);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Details(string Naim_Details, int Garant_ID, int Model_ID)
        {
            spConfiguration("ADD_Details");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_Details", Naim_Details);
                cmd.Parameters.AddWithValue("@Garant_ID", Garant_ID);
                cmd.Parameters.AddWithValue("@Model_ID", Model_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Details(int ID_Details, string Naim_Details, int Garant_ID, int Model_ID)
        {
            spConfiguration("Upd_Details");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Details", ID_Details);
                cmd.Parameters.AddWithValue("@Naim_Details", Naim_Details);
                cmd.Parameters.AddWithValue("@Garant_ID", Garant_ID);
                cmd.Parameters.AddWithValue("@Model_ID", Model_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Details(int ID_Details)
        {
            spConfiguration("Del_Details");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Details", ID_Details);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spLogical_Delete_Details(int ID_Details)
        {
            spConfiguration("Logical_Delete_Details");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Details", ID_Details);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Prihod_Details(int Count_Prih, string Data_Prih, int Details_ID)
        {
            spConfiguration("ADD_Prihod_Details");
            try
            {
                cmd.Parameters.AddWithValue("@Count_Prih", Count_Prih);
                cmd.Parameters.AddWithValue("@Data_Prih", Data_Prih);
                cmd.Parameters.AddWithValue("@Details_ID", Details_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Prihod_Details(int ID_Prihod, int Count_Prih, string Data_Prih, int Details_ID)
        {
            spConfiguration("Upd_Prihod_Details");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Prihod", ID_Prihod);
                cmd.Parameters.AddWithValue("@Count_Prih", Count_Prih);
                cmd.Parameters.AddWithValue("@Data_Prih", Data_Prih);
                cmd.Parameters.AddWithValue("@Details_ID", Details_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Prihod_Details(int ID_Prihod)
        {
            spConfiguration("Del_Prihod_Details");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Prihod", ID_Prihod);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spPrih_Logical_Delete(int ID_Prihod)
        {
            spConfiguration("Prih_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Prihod", ID_Prihod);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Sklad(int Details_ID, int Count_Det)
        {
            spConfiguration("ADD_Sklad");
            try
            {
                cmd.Parameters.AddWithValue("@Details_ID", Details_ID);
                cmd.Parameters.AddWithValue("@Count_Det", Count_Det);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Sklad(int ID_Sklad, int Details_ID, int Count_Det)
        {
            spConfiguration("Upd_Sklad");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Sklad", ID_Sklad);
                cmd.Parameters.AddWithValue("@Details_ID", Details_ID);
                cmd.Parameters.AddWithValue("@Count_Det", Count_Det);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Sklad(int ID_Sklad)
        {
            spConfiguration("Del_Sklad");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Sklad", ID_Sklad);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spSklad_Logical_Delete(int ID_Sklad)
        {
            spConfiguration("Sklad_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Sklad", ID_Sklad);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Services(string Naim_Services, decimal Stoimost_Serv, int Dlitelnost, int Details_ID)
        {
            spConfiguration("ADD_Services");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_Services", Naim_Services);
                cmd.Parameters.AddWithValue("@Stoimost_Serv", Stoimost_Serv);
                cmd.Parameters.AddWithValue("@Dlitelnost", Dlitelnost);
                cmd.Parameters.AddWithValue("@Details_ID", Details_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Services(int ID_Services, string Naim_Services, decimal Stoimost_Serv, int Dlitelnost, int Details_ID)
        {
            spConfiguration("Upd_Services");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Services", ID_Services);
                cmd.Parameters.AddWithValue("@Naim_Services", Naim_Services);
                cmd.Parameters.AddWithValue("@Stoimost_Serv", Stoimost_Serv);
                cmd.Parameters.AddWithValue("@Dlitelnost", Dlitelnost);
                cmd.Parameters.AddWithValue("@Details_ID", Details_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Services(int ID_Services)
        {
            spConfiguration("Del_Services");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Services", ID_Services);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spServices_Logical_Delete(int ID_Services)
        {
            spConfiguration("Services_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Services", ID_Services);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Store_Basket(string Login_Klt, int Services_ID)
        {
            spConfiguration("ADD_Store_Basket");
            try
            {
                cmd.Parameters.AddWithValue("@Login_Klt", Login_Klt);
                cmd.Parameters.AddWithValue("@Services_ID", Services_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Store_Basket(int ID_Store_Basket, string Login_Klt, int Services_ID)
        {
            spConfiguration("Upd_Store_Basket");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Store_Basket", ID_Store_Basket);
                cmd.Parameters.AddWithValue("@Login_Klt", Login_Klt);
                cmd.Parameters.AddWithValue("@Services_ID", Services_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Store_Basket(int ID_Store_Basket)
        {
            spConfiguration("Del_Store_Basket");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Store_Basket", ID_Store_Basket);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spAdd_Contracts(string Num_Contr, string Login_Kl, int Model_ID, string Login_St, int Treshchiny, int Tsarapiny, int Rabotosposobnost, string Comment)
        {
            spConfiguration("Add_Contracts");
            try
            {
                cmd.Parameters.AddWithValue("@Num_Contr", Num_Contr);
                cmd.Parameters.AddWithValue("@Login_Kl", Login_Kl);
                cmd.Parameters.AddWithValue("@Model_ID", Model_ID);
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                cmd.Parameters.AddWithValue("@Treshchiny", Treshchiny);
                cmd.Parameters.AddWithValue("@Tsarapiny", Tsarapiny);
                cmd.Parameters.AddWithValue("@Rabotosposobnost", Rabotosposobnost);
                cmd.Parameters.AddWithValue("@Comment", Comment);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Contracts(int ID_Contr, string Num_Contr, string Login_Kl, int Model_ID, string Login_St, int Treshchiny, int Tsarapiny, int Rabotosposobnost, string Comment)
        {
            spConfiguration("Upd_Contracts");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Contr", ID_Contr);
                cmd.Parameters.AddWithValue("@Num_Contr", Num_Contr);
                cmd.Parameters.AddWithValue("@Login_Kl", Login_Kl);
                cmd.Parameters.AddWithValue("@Model_ID", Model_ID);
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                cmd.Parameters.AddWithValue("@Treshchiny", Treshchiny);
                cmd.Parameters.AddWithValue("@Tsarapiny", Tsarapiny);
                cmd.Parameters.AddWithValue("@Rabotosposobnost", Rabotosposobnost);
                cmd.Parameters.AddWithValue("@Comment", Comment);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Contracts(int ID_Contr)
        {
            spConfiguration("Del_Contracts");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Contr", ID_Contr);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Errors[0].Class == 15)
                {
                    MessageBox.Show(ex.Message);
                }
                if (ex.Errors[0].Class == 16)
                {
                    DialogResult result = MessageBox.Show(ex.Message + "\nХотите открыть форму тестирований?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    switch (result)

                    {

                        case DialogResult.Yes:
                            Testirovaniya remonti = new Testirovaniya();
                            MainWindow main = new MainWindow();
                            main.Zatemn();
                            remonti.Show();
                            break;

                        case DialogResult.No:
                            ; break;

                    }
                    
                }
                if (ex.Errors[0].Class == 17)
                {
                    DialogResult result = MessageBox.Show(ex.Message + "\nХотите открыть форму ремонтов?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    switch (result)

                    {

                        case DialogResult.Yes:
                            Remonti remonti = new Remonti();
                            MainWindow main = new MainWindow();
                            main.Zatemn();
                            remonti.Show();
                            break;

                        case DialogResult.No:
                            ; break;

                    }
                }
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Tests(int Contr_ID, int Zaversh)
        {
            spConfiguration("ADD_Tests");
            try
            {
                cmd.Parameters.AddWithValue("@Contr_ID", Contr_ID);
                cmd.Parameters.AddWithValue("@Zaversh", Zaversh);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Tests(int ID_Test, int Contr_ID, int Zaversh)
        {
            spConfiguration("Upd_Tests");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Test", ID_Test);
                cmd.Parameters.AddWithValue("@Contr_ID", Contr_ID);
                cmd.Parameters.AddWithValue("@Zaversh", Zaversh);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Tests(int ID_Test)
        {
            spConfiguration("Upd_Tests");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Test", ID_Test);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Repairs(int Contr_ID, string Date_Start, string Date_End, string Status, int Services_ID)
        {
            spConfiguration("ADD_Repairs");
            try
            {
                cmd.Parameters.AddWithValue("@Contr_ID", Contr_ID);
                cmd.Parameters.AddWithValue("@Date_Start", Date_Start);
                cmd.Parameters.AddWithValue("@Date_End", Date_End);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Services_ID", Services_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Repairs(int ID_Repairs, int Contr_ID, string Date_Start, string Date_End, string Status, int Services_ID)
        {
            spConfiguration("Upd_Repairs");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Repairs", ID_Repairs);
                cmd.Parameters.AddWithValue("@Contr_ID", Contr_ID);
                cmd.Parameters.AddWithValue("@Date_Start", Date_Start);
                cmd.Parameters.AddWithValue("@Date_End", Date_End);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Services_ID", Services_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Repairs(int ID_Repairs)
        {
            spConfiguration("Del_Repairs");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Repairs", ID_Repairs);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spAdd_Chek(string Num_Check, string Data_Prod, string Time_Prod)
        {
            spConfiguration("Add_Chek");
            try
            {
                cmd.Parameters.AddWithValue("@Num_Check", Num_Check);
                cmd.Parameters.AddWithValue("@Data_Prod", Data_Prod);
                cmd.Parameters.AddWithValue("@Time_Prod", Time_Prod);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Chek(int ID_Chek, string Num_Check, string Data_Prod, string Time_Prod)
        {
            spConfiguration("Upd_Chek");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Chek", ID_Chek);
                cmd.Parameters.AddWithValue("@Num_Check", Num_Check);
                cmd.Parameters.AddWithValue("@Data_Prod", Data_Prod);
                cmd.Parameters.AddWithValue("@Time_Prod", Time_Prod);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Chek(int ID_Chek)
        {
            spConfiguration("Del_Chek");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Chek", ID_Chek);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spLogical_Delete_Chek(int ID_Chek)
        {
            spConfiguration("Logical_Delete_Chek");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Chek", ID_Chek);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spADD_Dan_Check(int Chek_ID, int Repairs_ID)
        {
            spConfiguration("ADD_Dan_Check");
            try
            {
                cmd.Parameters.AddWithValue("@Chek_ID", Chek_ID);
                cmd.Parameters.AddWithValue("@Repairs_ID", Repairs_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spUpd_Dan_Check(int ID_Dan_Chek, int Chek_ID, int Repairs_ID, decimal Stoimost)
        {
            spConfiguration("Upd_Dan_Check");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Dan_Chek", ID_Dan_Chek);
                cmd.Parameters.AddWithValue("@Chek_ID", Chek_ID);
                cmd.Parameters.AddWithValue("@Repairs_ID", Repairs_ID);
                cmd.Parameters.AddWithValue("@Stoimost", Stoimost);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void spDel_Dan_Check(int ID_Dan_Chek)
        {
            spConfiguration("Del_Dan_Check");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Dan_Chek", ID_Dan_Chek);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpADD_Role(string Naim_Role, int Roles, int Profiles, int Yslugi, int Dogovora, int Klients, int Remonti,
int Statusi, int Prihodi, int Sklad, int Lich_Dela, int Doljnosti,
int Otdeli, int Detali, int Tipi_Ystr, int Proizvodit_Yastr, int Modeli_Ystr, int Testirovaniya,
 int Isp_sroki, int Cheki)
        {
            spConfiguration("ADD_Role");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_Role", Naim_Role);
                cmd.Parameters.AddWithValue("@Roles", Roles);
                cmd.Parameters.AddWithValue("@Profiles", Profiles);
                cmd.Parameters.AddWithValue("@Yslugi", Yslugi);
                cmd.Parameters.AddWithValue("@Dogovora", Dogovora);
                cmd.Parameters.AddWithValue("@Klients", Klients);
                cmd.Parameters.AddWithValue("@Remonti", Remonti);
                cmd.Parameters.AddWithValue("@Statusi", Statusi);
                cmd.Parameters.AddWithValue("@Prihodi", Prihodi);
                cmd.Parameters.AddWithValue("@Sklad", Sklad);
                cmd.Parameters.AddWithValue("@Lich_Dela", Lich_Dela);
                cmd.Parameters.AddWithValue("@Doljnosti", Doljnosti);
                cmd.Parameters.AddWithValue("@Otdeli", Otdeli);
                cmd.Parameters.AddWithValue("@Detali", Detali);
                cmd.Parameters.AddWithValue("@Tipi_Ystr", Tipi_Ystr);
                cmd.Parameters.AddWithValue("@Proizvodit_Yastr", Proizvodit_Yastr);
                cmd.Parameters.AddWithValue("@Modeli_Ystr", Modeli_Ystr);
                cmd.Parameters.AddWithValue("@Testirovaniya", Testirovaniya);
                cmd.Parameters.AddWithValue("@Isp_sroki", Isp_sroki);
                cmd.Parameters.AddWithValue("@Cheki", Cheki);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ex.Errors[0].Class == 16)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Role(int ID_Role, string Naim_Role, int Roles, int Profiles, int Yslugi, int Dogovora, int Klients, int Remonti,
int Statusi, int Prihodi, int Sklad, int Lich_Dela, int Doljnosti,
int Otdeli, int Detali, int Tipi_Ystr, int Proizvodit_Yastr, int Modeli_Ystr, int Testirovaniya
, int Isp_sroki, int Cheki)
        {
            spConfiguration("Upd_Role");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Role", ID_Role);
                cmd.Parameters.AddWithValue("@Naim_Role", Naim_Role);
                cmd.Parameters.AddWithValue("@Roles", Roles);
                cmd.Parameters.AddWithValue("@Profiles", Profiles);
                cmd.Parameters.AddWithValue("@Yslugi", Yslugi);
                cmd.Parameters.AddWithValue("@Dogovora", Dogovora);
                cmd.Parameters.AddWithValue("@Klients", Klients);
                cmd.Parameters.AddWithValue("@Remonti", Remonti);
                cmd.Parameters.AddWithValue("@Statusi", Statusi);
                cmd.Parameters.AddWithValue("@Prihodi", Prihodi);
                cmd.Parameters.AddWithValue("@Sklad", Sklad);
                cmd.Parameters.AddWithValue("@Lich_Dela", Lich_Dela);
                cmd.Parameters.AddWithValue("@Doljnosti", Doljnosti);
                cmd.Parameters.AddWithValue("@Otdeli", Otdeli);
                cmd.Parameters.AddWithValue("@Detali", Detali);
                cmd.Parameters.AddWithValue("@Tipi_Ystr", Tipi_Ystr);
                cmd.Parameters.AddWithValue("@Proizvodit_Yastr", Proizvodit_Yastr);
                cmd.Parameters.AddWithValue("@Modeli_Ystr", Modeli_Ystr);
                cmd.Parameters.AddWithValue("@Testirovaniya", Testirovaniya);
                cmd.Parameters.AddWithValue("@Isp_sroki", Isp_sroki);
                cmd.Parameters.AddWithValue("@Cheki", Cheki);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Role(int ID_Role)
        {
            spConfiguration("Del_Role");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Role", ID_Role);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpRole_Logical_Delete(int ID_Role)
        {
            spConfiguration("Role_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Role", ID_Role);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Профили

        public void SpADD_Profile(string Login, string Password, string phone, string email,
        int Role_ID, string Profile_Photo, int Active_Profile)
        {
            spConfiguration("ADD_Profile");
            try
            {
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Role_ID", Role_ID);
                cmd.Parameters.AddWithValue("@Profile_Photo", Profile_Photo);
                cmd.Parameters.AddWithValue("@Active_Profile", Active_Profile);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Profile(string Login, string Password, string phone, string email,
        int Role_ID, string Profile_Photo, int Active_Profile)
        {
            spConfiguration("Upd_Profile");
            try
            {
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Role_ID", Role_ID);
                cmd.Parameters.AddWithValue("@Profile_Photo", Profile_Photo);
                cmd.Parameters.AddWithValue("@Active_Profile", Active_Profile);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_PassProfile(string Login, string Password)
        {
            spConfiguration("Upd_PassProfile");
            try
            {
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Password", Password);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_AvaProfile(string Login, string Profile_Photo)
        {
            spConfiguration("Upd_AvaProfile");
            try
            {
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Profile_Photo", Profile_Photo);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Profile(string Login)
        {
            spConfiguration("Del_Profile");
            try
            {
                cmd.Parameters.AddWithValue("@Login", Login);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpProfile_Logical_Delete(string Login)
        {
            spConfiguration("Profile_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@Login", Login);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Клиенты

        public void SpADD_Klient(string Login_Kl, string Familiya, string Imya, string Otchestvo,
        string Data_Rojd)
        {
            spConfiguration("ADD_Klient");
            try
            {
                cmd.Parameters.AddWithValue("@Login_Kl", Login_Kl);
                cmd.Parameters.AddWithValue("@Familiya", Familiya);
                cmd.Parameters.AddWithValue("@Imya", Imya);
                cmd.Parameters.AddWithValue("@Otchestvo", Otchestvo);
                cmd.Parameters.AddWithValue("@Data_Rojd", Data_Rojd);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Klient(string Login_Kl, string Familiya, string Imya, string Otchestvo,
        string Data_Rojd)
        {
            spConfiguration("Upd_Klient");
            try
            {
                cmd.Parameters.AddWithValue("@Login_Kl", Login_Kl);
                cmd.Parameters.AddWithValue("@Familiya", Familiya);
                cmd.Parameters.AddWithValue("@Imya", Imya);
                cmd.Parameters.AddWithValue("@Otchestvo", Otchestvo);
                cmd.Parameters.AddWithValue("@Data_Rojd", Data_Rojd);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Klient(string Login_Kl)
        {
            spConfiguration("Del_Klient");
            try
            {
                cmd.Parameters.AddWithValue("@Login_Kl", Login_Kl);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (ex.Errors[0].Class == 16)
                {
                    MessageBox.Show(ex.Message);
                }
                if (ex.Errors[0].Class == 17)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpKlient_Logical_Delete(string Login_Kl)
        {
            spConfiguration("Klient_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@Login_Kl", Login_Kl);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Сотрудники

        public void SpADD_Sotr(string Login_St, int Num_Lich_Dela, string Familiya, string Imya, string Otchestvo,
        string DateOfRojd, int S_Pas, int N_Pas, string Adres_Proj, int Dolj_ID)
        {
            spConfiguration("ADD_Sotr");
            try
            {
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                cmd.Parameters.AddWithValue("@Num_Lich_Dela", Num_Lich_Dela);
                cmd.Parameters.AddWithValue("@Familiya", Familiya);
                cmd.Parameters.AddWithValue("@Imya", Imya);
                cmd.Parameters.AddWithValue("@Otchestvo", Otchestvo);
                cmd.Parameters.AddWithValue("@DateOfRojd", DateOfRojd);
                cmd.Parameters.AddWithValue("@S_Pas", S_Pas);
                cmd.Parameters.AddWithValue("@N_Pas", N_Pas);
                cmd.Parameters.AddWithValue("@Adres_Proj", Adres_Proj);
                cmd.Parameters.AddWithValue("@Dolj_ID", Dolj_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Sotr(string Login_St, int Num_Lich_Dela, string Familiya, string Imya, string Otchestvo,
        string DateOfRojd, int S_Pas, int N_Pas, string Adres_Proj, int Dolj_ID)
        {
            spConfiguration("Upd_Sotr");
            try
            {
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                cmd.Parameters.AddWithValue("@Num_Lich_Dela", Num_Lich_Dela);
                cmd.Parameters.AddWithValue("@Familiya", Familiya);
                cmd.Parameters.AddWithValue("@Imya", Imya);
                cmd.Parameters.AddWithValue("@Otchestvo", Otchestvo);
                cmd.Parameters.AddWithValue("@DateOfRojd", DateOfRojd);
                cmd.Parameters.AddWithValue("@S_Pas", S_Pas);
                cmd.Parameters.AddWithValue("@N_Pas", N_Pas);
                cmd.Parameters.AddWithValue("@Adres_Proj", Adres_Proj);
                cmd.Parameters.AddWithValue("@Dolj_ID", Dolj_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Sotr(string Login_St)
        {
            spConfiguration("Del_Sotr");
            try
            {
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpSotr_Logical_Delete(int Login_St)
        {
            spConfiguration("Sotr_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Должности

        public void SpADD_Dolj(int Otdel_ID, string Naim_Dolj, decimal Oklad, int Dney_Na_Isp_Srok)
        {
            spConfiguration("ADD_Dolj");
            try
            {
                cmd.Parameters.AddWithValue("@Otdel_ID", Otdel_ID);
                cmd.Parameters.AddWithValue("@Naim_Dolj", Naim_Dolj);
                cmd.Parameters.AddWithValue("@Oklad", Oklad);
                cmd.Parameters.AddWithValue("@Dney_Na_Isp_Srok", Dney_Na_Isp_Srok);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Dolj(int ID_Dolj, int Otdel_ID, string Naim_Dolj, decimal Oklad, int Dney_Na_Isp_Srok)
        {
            spConfiguration("Upd_Dolj");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Dolj", ID_Dolj);
                cmd.Parameters.AddWithValue("@Otdel_ID", Otdel_ID);
                cmd.Parameters.AddWithValue("@Naim_Dolj", Naim_Dolj);
                cmd.Parameters.AddWithValue("@Oklad", Oklad);
                cmd.Parameters.AddWithValue("@Dney_Na_Isp_Srok", Dney_Na_Isp_Srok);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Dolj(int ID_Dolj)
        {
            spConfiguration("Del_Dolj");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Dolj", ID_Dolj);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpLogical_Delete_Dolj(int ID_Dolj)
        {
            spConfiguration("Logical_Delete_Dolj");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Dolj", ID_Dolj);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Отделы

        public void SpADD_Otdel(string Naim_Otdela, int Count_Chel)
        {
            spConfiguration("ADD_Otdel");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_Otdela", Naim_Otdela);
                cmd.Parameters.AddWithValue("@Count_Chel", Count_Chel);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Otdel(int ID_Otdel, string Naim_Otdela, int Count_Chel)
        {
            spConfiguration("Upd_Otdel");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Otdel", ID_Otdel);
                cmd.Parameters.AddWithValue("@Naim_Otdela", Naim_Otdela);
                cmd.Parameters.AddWithValue("@Count_Chel", Count_Chel);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Otdel(int ID_Otdel)
        {
            spConfiguration("Del_Otdel");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Otdel", ID_Otdel);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpOtdel_Logical_Delete(int ID_Otdel)
        {
            spConfiguration("Otdel_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Otdel", ID_Otdel);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Производители деталей

        public void SpADD_Proizvod_Device(string Naim_Proizvod, int Type_ID)
        {
            spConfiguration("ADD_Proizvod_Device");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_Proizvod", Naim_Proizvod);
                cmd.Parameters.AddWithValue("@Type_ID", Type_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Proizvod_Device(int ID_Proizvod, string Naim_Proizvod, int Type_ID)
        {
            spConfiguration("Upd_Proizvod_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Proizvod", ID_Proizvod);
                cmd.Parameters.AddWithValue("@Naim_Proizvod", Naim_Proizvod);
                cmd.Parameters.AddWithValue("@Type_ID", Type_ID);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Proizvod_Device(int ID_Proizvod)
        {
            spConfiguration("Del_Proizvod_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Proizvod", ID_Proizvod);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpProizv_Logical_Delete(int ID_Proizvod)
        {
            spConfiguration("Del_Proizvod_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Proizvod", ID_Proizvod);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Типы девайсов

        public void SpADD_Type_Device(string Naim_type)
        {
            spConfiguration("ADD_Type_Device");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_type", Naim_type);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Type_Device(int ID_Type, string Naim_type)
        {
            spConfiguration("Upd_Type_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Type", ID_Type);
                cmd.Parameters.AddWithValue("@Naim_type", Naim_type);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Type_Device(int ID_Type)
        {
            spConfiguration("Del_Type_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Type", ID_Type);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpType_Logical_Delete(int ID_Type)
        {
            spConfiguration("Type_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Type", ID_Type);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Модели устройств

        public void SpADD_Model_Device(string Naim_Model, int Proizvod_ID, string Model_Photo)
        {
            spConfiguration("ADD_Model_Device");
            try
            {
                cmd.Parameters.AddWithValue("@Naim_Model", Naim_Model);
                cmd.Parameters.AddWithValue("@Proizvod_ID", Proizvod_ID);
                cmd.Parameters.AddWithValue("@Model_Photo", Model_Photo);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Model_Device(int ID_Model, string Naim_Model, int Proizvod_ID, string Model_Photo)
        {
            spConfiguration("Upd_Model_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Model", ID_Model);
                cmd.Parameters.AddWithValue("@Naim_Model", Naim_Model);
                cmd.Parameters.AddWithValue("@Proizvod_ID", Proizvod_ID);
                cmd.Parameters.AddWithValue("@Model_Photo", Model_Photo);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Model_Device(int ID_Model)
        {
            spConfiguration("Del_Model_Device");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Model", ID_Model);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpModel_Logical_Delete(int ID_Model)
        {
            spConfiguration("Model_Logical_Delete");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Model", ID_Model);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        //Испытательный срок

        public void SpADD_Isp_srok(string Login_St, string Data_Start, string Data_End)
        {
            spConfiguration("ADD_Isp_srok");
            try
            {
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                cmd.Parameters.AddWithValue("@Data_Start", Data_Start);
                cmd.Parameters.AddWithValue("@Data_End", Data_End);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpUpd_Isp_srok(int ID_Isp, string Login_St, string Data_Start, string Data_End)
        {
            spConfiguration("Upd_Isp_srok");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Isp", ID_Isp);
                cmd.Parameters.AddWithValue("@Login_St", Login_St);
                cmd.Parameters.AddWithValue("@Data_Start", Data_Start);
                cmd.Parameters.AddWithValue("@Data_End", Data_End);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void SpDel_Isp_srok(int ID_Isp)
        {
            spConfiguration("Del_Isp_srok");
            try
            {
                cmd.Parameters.AddWithValue("@ID_Isp", ID_Isp);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

    }
}
