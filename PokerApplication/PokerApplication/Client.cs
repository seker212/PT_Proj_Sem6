using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PokerApplication
{
    public class Client
    {
       public string apiAddress, apiPort, userName,userCode,tableCode;
       public string endpoint { get; set; }
       public httpVerbs httpMethod { get; set; }
       public Client() {
            endpoint = string.Empty;
            httpMethod = httpVerbs.GET;
        }
        public enum httpVerbs
        {
            GET,
            POST,
            DELETE
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
            string[] received = makeRequest(api_Request,0);
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
        public string createGame()
        {      
            var api_Request = "http://" + apiAddress + ":" + apiPort + "/newtable";
            string[] received = makeRequest(api_Request,1);
            Regex reg = new Regex("[*'\",_&#^@]");
            received[0] = reg.Replace(received[0], string.Empty);
            return received[0];
        }
        public bool joinGame(string joinCode)
        {
            var message = "http://" + apiAddress + ":" + apiPort + "/newtable/join/" + joinCode + "?playerName=" + userName;
            userCode = makeRequest(message,1)[0];
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
        public string Login(string login, string passwd)
        {
            string api_Request = "http://127.0.0.1:29345/doc/swagger/";
            string[] received = makeRequest(api_Request,0);
            return "hello";
            /*
            if (Regex.IsMatch(login, @"^[a-zA-Z0-9]+$"))
            {
                // Logowanie użytkownika po peselu
                if (Regex.IsMatch(login, @"^[0-9]+$"))  
                {
                    if(login.Length!=11)
                    {
                        return "Invalid Login or Password";
                    }
                    api_Request = "http://127.0.0.1:29345/api/users?pesel="+login;
                }
                else // Logowanie administratora po loginie
                {
                    api_Request = "http://127.0.0.1:5000/api/employees?username=" + login;
                }

            }
            else
            {
                return "Invalid Login or Password";
            }
            string hash = "";
            string[] received = makeRequest(api_Request,1);
            if(received.Length!=0 && received!=null && received[0] != null && received[1] != null)
            {
                //TU HASZOWAĆ
                
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    hash = GetHash(sha256Hash, passwd);

                    Console.WriteLine("Verifying the hash...");

                    if (VerifyHash(sha256Hash, passwd, hash))
                    {
                        Console.WriteLine("The hashes are the same.");
                        Console.WriteLine(hash);
                    }
                    else
                    {
                        Console.WriteLine("The hashes are not same.");
                    }
                }
                if (received[0].Equals(login) && received[1].Equals(hash))
                {
                    return "Logged In";
                }
                else
                {
                    return "Invalid Login or Password";
                }
            }
            else
            {
                return "Invalid Login or Password";
            }
            */



        }
        public string[] GetData(string login, string passwd)
        {
            string api_Request = "";
            if (Regex.IsMatch(login, @"^[a-zA-Z0-9]+$"))
            {
                // Logowanie użytkownika po peselu
                if (Regex.IsMatch(login, @"^[0-9]+$"))
                {
                    if (login.Length == 11)
                    {
                        api_Request = "http://127.0.0.1:5000/api/results?pesel=" + login;
                    }
                    
                }
                else // Logowanie administratora po loginie
                {
                    api_Request = "http://127.0.0.1:5000/api/results?username=" + login;
                }

            }
            string[] received = new string[10];
            received = makeRequest(api_Request,0);
            Console.WriteLine(received);
            //TEST
            return received;


        }
        /// <summary>
        /// Makes API request
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string[] makeRequest(string message,int type)
        {
            string msgResponse = string.Empty;
            if(type==0)
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(message);

            request.Method = httpMethod.ToString();

            try {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GDY RESPONSE NIE JEST 200 OK
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //TODO
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
                    String[] resp = new String[2];
                    resp[0] = "Error Occured";
                    resp[1] = "Error";
                    return resp;
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
    }
}
