using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;
using ANYE_Balls;
using System.Xml.Linq;

namespace ANYE_Balls
{
    public class Json
    {
        public static void writejson(string shuxing, string zhi)
        {
            if (File.Exists(MainForm.filePath))
            {
                string jsonf = File.ReadAllText(MainForm.filePath);
                try
                {
                    JObject root = JObject.Parse(jsonf);
                    root[shuxing] = zhi;
                    jsonf = root.ToString();
                }
                catch
                {
                    JObject root = new JObject();
                    root[shuxing] = zhi;
                    jsonf = root.ToString();
                }
                File.WriteAllText(MainForm.filePath, jsonf);
            }
            else
            {
                using (FileStream fs = File.Create(MainForm.filePath)) { }
                JObject root = new JObject();
                root[shuxing] = zhi;
                string jsonf = root.ToString();
                File.WriteAllText(MainForm.filePath, jsonf);
            }
        }
        public static string readjson(string shuxing)
        {
            if (File.Exists(MainForm.filePath))
            {
                string jsonf = File.ReadAllText(MainForm.filePath);
                JObject root;
                try
                {
                    root = JObject.Parse(jsonf);
                }
                catch
                {
                    root = new JObject();
                }
                if (root.ContainsKey(shuxing))
                {
                    return root[shuxing].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        public static bool checkjson(string shuxing)
        {
            if (File.Exists(MainForm.filePath))
            {
                string jsonf = File.ReadAllText(MainForm.filePath);
                try
                {
                    JObject root = JObject.Parse(jsonf);
                    return root.ContainsKey(shuxing);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void writejson2(string shuxing, string zhi)
        {
            if (File.Exists(yanzhengck.filePath))
            {
                string jsonf = File.ReadAllText(yanzhengck.filePath);
                JObject root = JObject.Parse(jsonf);
                root[shuxing] = zhi;
                jsonf = root.ToString();
                File.WriteAllText(yanzhengck.filePath, jsonf);
            }
            else
            {
                using (FileStream fs = File.Create(yanzhengck.filePath)) { }
                JObject root = new JObject();
                root[shuxing] = zhi;
                string jsonf = root.ToString();
                File.WriteAllText(yanzhengck.filePath, jsonf);
            }
        }
        public static string readjson2(string shuxing)
        {
            if (File.Exists(yanzhengck.filePath))
            {
                string jsonf = File.ReadAllText(yanzhengck.filePath);
                JObject root = JObject.Parse(jsonf);
                if (root.ContainsKey(shuxing))
                {
                    return root[shuxing].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        public static bool checkjson2(string shuxing)
        {
            if (File.Exists(yanzhengck.filePath))
            {
                string jsonf = File.ReadAllText(yanzhengck.filePath);
                JObject root = JObject.Parse(jsonf);
                return root.ContainsKey(shuxing);
            }
            else
            {
                return false;
            }
        }
    }
}
