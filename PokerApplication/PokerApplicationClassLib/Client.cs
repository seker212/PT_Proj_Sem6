﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace PokerApplicationClassLib
{
    public class Client
    {
       public string apiAddress, apiPort, userName,userCode,tableCode,path,card1,card2;
       public Game game;
       public List<string> users;
       public string endpoint { get; set; }
       public httpVerbs httpMethod { get; set; }
       public Client() {
            
            endpoint = string.Empty;
            httpMethod = httpVerbs.GET;
            users = new List<string>();
            game = new Game();
        }
        public enum httpVerbs
        {
            GET,
            POST,
            DELETE,
            PUT
        }
        /// <summary>
        /// Checks if server is responding
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Initialize(string ipAddress, string port, string username)
        {
            //CHANGE REQUEST FOR PING
            var api_Request = "http://" + ipAddress + ":" + port + "/doc/swagger/";
            string[] received = MakeRequest(api_Request,0);
            if (!String.IsNullOrEmpty(received[0]) )
            {
                this.apiAddress = ipAddress;
                this.apiPort = port;
                this.userName = username;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Creates a new poker table, return unique table code.
        /// </summary>
        /// <returns></returns>
        public string CreateGame()
        {      
            var api_Request = "http://" + apiAddress + ":" + apiPort + "/newtable";
            string[] received = MakeRequest(api_Request,1);
            Regex reg = new Regex("[*'\",_&#^@]");
            received[0] = reg.Replace(received[0], string.Empty);
            return received[0];
        }
        public bool JoinGame(string joinCode)
        {

            var message = "http://" + apiAddress + ":" + apiPort + "/newtable/join/" + joinCode + "?playerName=" + userName;
            userCode = MakeRequest(message,1)[0];
            Regex reg = new Regex("[*'\",_&#^@]");
            userCode = reg.Replace(userCode, string.Empty);
            if(userCode==""||userCode==null)
            {
                return false;
            }
            else
            {
                tableCode = joinCode;
                return true;
            }
            
        }
        
        /// <summary>
        /// Checks data on input before sending to server
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckData(string ipAddress, string port, string username)
        {
            if ((new Regex(@"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")).IsMatch(ipAddress))
            {
                port = port.Replace(" ", "");
                username = username.Replace(" ", "");
                if(String.IsNullOrEmpty(port)|| String.IsNullOrEmpty(username))
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return false;
            }

            

        }
       
        /// <summary>
        /// Makes API request
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string[] MakeRequest(string message,int type)
        {
            string msgResponse = string.Empty;
            message = message.Replace("http", "https");
            if (type==0)
            {
                httpMethod = httpVerbs.GET;
            }
            if(type==1)
            {
                httpMethod = httpVerbs.POST;
            }
            if(type==2)
            {
                httpMethod = httpVerbs.DELETE;
            }
            if(type==3)
            {
                httpMethod = httpVerbs.PUT;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(message);

            request.Method = httpMethod.ToString();
            request.ServerCertificateValidationCallback += (a, b, c, d) => true;
            try {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GDY RESPONSE NIE JEST 200 OK
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //TODO
                        if (response.StatusCode != HttpStatusCode.NotFound)
                        {
                            if(type==0)
                            {
                                string[] resp = new string[] { "NO" };
                                return resp;
                                    
                            }
                        }
                        string[] stringResponse = new string[] { "" };
                        stringResponse[0]= "NAK";

                        return stringResponse;
                        throw new Exception("Error code: " + response.StatusCode);
                       

                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                String[] resp = new String[1000];
                                String jsonResponse = "";
                                int i = 0;
                                jsonResponse = reader.ReadLine();
                                while (jsonResponse != null)
                                {
                                    
                                    resp[i] = jsonResponse;
                                    i++;
                                    jsonResponse = reader.ReadLine();
                                }
                                
                                return resp;

                            }
                        }
                        else
                        {
                            return new string[0];
                        }

                    }
                }

            }
                catch(System.Net.WebException)
                {
                   if( message=="https://" + apiAddress + ":" + apiPort + "/table/" + tableCode)
                   {
                        String[] resp = new String[1];
                        resp[0] = "NO";
                        return resp;
                    }
                   else
                   {
                        String[] resp = new String[2];
                        resp[0] = "";
                        resp[1] = "Error";
                        return resp;
                   }
                   
                }

        }
        #region Hash
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
        #endregion 
        public bool Started()
        {
            var request = "http://"+apiAddress+":"+apiPort+"/table/" +tableCode;
            
            if (MakeRequest(request, 0)[0] != "NO")
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }
        public bool GetCards()
        {
            var message = "http://"+apiAddress+":"+apiPort+"/table/"+tableCode+"/playercards?playerID="+userCode;
            var cards =MakeRequest(message, 0)[0];
            Console.WriteLine(cards);
            cards = Regex.Replace(cards, @"[^0-9a-zA-Z:,]+", "");
            Console.WriteLine(cards);
            cards = cards.Replace("rank", "");
            cards = cards.Replace("suit", "");
            cards = cards.Replace(":", "");
            cards = cards.Replace("spades", "S");
            cards = cards.Replace("hearts", "H");
            cards = cards.Replace("clubs", "C");
            cards = cards.Replace("diamonds", "D");
            var MyCards = cards.Split(',');
            card1 = MyCards[0] + MyCards[1];
            card2 = MyCards[2] + MyCards[3];

            return true;
        }
    }   
}
