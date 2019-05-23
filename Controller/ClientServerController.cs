using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using ClassLibrary;
using CourseWork_SAIPIS.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CourseWork_SAIPIS
{
    public static class ClientServerController
    {
        static int port = 9999; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        private static NetworkStream netStream;

        public static void Connect()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(address, port);
                netStream = client.GetStream();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        static void SendRequest(Request request)
        {
            try
            {

                //сериализация запроса в Json и отправка
                string json = JsonConvert.SerializeObject(request);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                netStream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static ArrayList GetResponse()
        {
            try
            {
                byte[] data2 = new byte[1000000000];
                int bytesCount = netStream.Read(data2, 0, data2.Length);
                string response = Encoding.UTF8.GetString(data2, 0, bytesCount);
                Debug.WriteLine(response);
                //MessageBox.Show(response);
                //десериализация
                ArrayList responseArrayList = new ArrayList();
                try
                {
                    responseArrayList = JsonConvert.DeserializeObject<ArrayList>(response);


                }
                catch (Exception e)
                {
                    MessageBox.Show(response + "\n\n" + e.Message);
                    return null;

                }
                return responseArrayList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;

            }

        }

        public static int Login(string username, string password)
        {
            //формирование запроса
            Request request = new Request();
            request.fuction = "login";
            request.parameters.Add(username);
            request.parameters.Add(password);

            //отправка
            SendRequest(request);

            //получение ответа
            ArrayList response = GetResponse();
            if (response != null)
            {
                int result = Convert.ToInt32(response[0]);
                if (result == 2)
                {
                    mySystem.CurrUserId = Convert.ToInt32(response[1]);
                    mySystem.UserStatus = (string)response[2];

                }

                return result;
            }

            return 0; 
        }

        public static int Regitration(string username, string password)
        {
            Request request = new Request();
            request.fuction = "registration";
            request.parameters.Add(username);
            request.parameters.Add(password);

            SendRequest(request);



            ArrayList responseObj = GetResponse();
            if (responseObj != null)
            {
                int result = 0;
                try
                {
                    result = Convert.ToInt32(responseObj[0]);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return result;
            }

            return 0;

        }

        //Not tested
        public static List<Users> userList()
        {
            Request request = new Request(){fuction = "userList"};

            SendRequest(request);
            ArrayList array = GetResponse();
            if (array != null)
            {
                JArray arr = JArray.FromObject(array[0]);
                List<Users> list = new List<Users>();
                foreach (var user in arr)
                {
                    try
                    {
                        Debug.WriteLine(user.ToObject<Users>());
                        list.Add(user.ToObject<Users>());
                    }
                    catch (Exception e)
                    {
                    }
                }
                return list;
            }

            return null;

        }

        public static List<Experts> expertsList()
        {
            Request request = new Request() { fuction = "expertsList" };
            SendRequest(request);
            ArrayList array = GetResponse();
            if (array != null)
            {
                JArray arr = JArray.FromObject(array[0]);
                List<Experts> list = new List<Experts>();
                foreach (var user in arr)
                {
                    try
                    {
                        list.Add(user.ToObject<Experts>());
                    }
                    catch (Exception e)
                    {
                    }
                }
                return list;
                
            }
            return null;
        }

        public static List<Invoice> invoiceList()
        {
            Request request = new Request() { fuction = "invoiceList" };
            SendRequest(request);
            ArrayList array = GetResponse();
            JArray arr = JArray.FromObject(array[0]);
            List<Invoice> list = new List<Invoice>();
            foreach (var user in arr)
            {
                try
                {
                    list.Add(user.ToObject<Invoice>());
                }
                catch (Exception e)
                {
                }
            }
            return list;
        }

        public static List<Clients> clientsList()
        {
            Request request = new Request() { fuction = "clientsList" };
            SendRequest(request);
            ArrayList array = GetResponse();
            JArray arr = JArray.FromObject(array[0]);
            List<Clients> list = new List<Clients>();
            foreach (var user in arr)
            {
                try
                {
                    list.Add(user.ToObject<Clients>());
                }
                catch (Exception e)
                {
                }
            }
            return list;
        }

        public static List<EventsList> eventsLists()
        {
            Request request = new Request() { fuction = "eventsList" };
            SendRequest(request);
            ArrayList array = GetResponse();
            JArray arr = JArray.FromObject(array[0]);
            List<EventsList> list = new List<EventsList>();
            foreach (var user in arr)
            {
                try
                {
                    list.Add(user.ToObject<EventsList>());
                }
                catch (Exception e)
                {
                }
            }
            return list;
        }

        public static ArrayList currnetPoints()
        {
            Request request = new Request() { fuction = "currentPoints" };
            SendRequest(request);
            ArrayList list = GetResponse();
            return list;
        }

        public static void addInvoice(Invoice invoice)
        {
            Request request = new Request() { fuction = "addInvoice"};
            request.parameters.Add(invoice);
            SendRequest(request);
        }

        public static void expertsFunction()
        {

        }

        public static void method()
        {

        }

        public static int SaveChangesUsers(List<Users> list)
        {
            Request request = new Request(){fuction = "saveChanges"+"Users"};
            Debug.WriteLine(request.fuction);
            request.parameters.Add(list);

            SendRequest(request);

            ArrayList array = GetResponse();
            //JArray jArray = (JArray)array[0];
            int result = 0;
            try
            {
                result = Convert.ToInt32(array[0]);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            if (result == 0)
            {
                throw new Exception("Error adding data");
            }

            return result;
        }

        public static int SaveChangesExperts(List<Experts> list)
        {
            Request request = new Request() { fuction = "saveChanges" + "Experts" };
            Debug.WriteLine(request.fuction);
            request.parameters.Add(list);

            SendRequest(request);

            ArrayList array = GetResponse();
            //JArray jArray = (JArray)array[0];
            int result = 0;
            try
            {
                result = Convert.ToInt32(array[0]);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            if (result == 0)
            {
                throw new Exception("Error adding data");
            }

            return result;
        }

        public static void SaveChangesEvents(List<EventsList> list)
        {
            Request request = new Request() { fuction = "saveChanges" + "Events" };
            Debug.WriteLine(request.fuction);
            request.parameters.Add(list);

            SendRequest(request);

            ArrayList array = GetResponse();
            //JArray jArray = (JArray)array[0];
            int result = 0;
            try
            {
                result = Convert.ToInt32(array[0]);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            if (result == 0)
            {
                throw new Exception("Error adding data");
            }
        }
    }
}