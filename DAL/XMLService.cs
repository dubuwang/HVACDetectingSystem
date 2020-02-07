using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Models;

namespace DAL
{
    /// <summary>
    /// XML文件访问类
    /// </summary>
    public class XMLService
    {
        // 存放变量的XML文件路径
        private static readonly string pathParams = System.Windows.Forms.Application.StartupPath + "\\ConfigFile\\" + "Params.xml";

        private static readonly string pathCommon = System.Windows.Forms.Application.StartupPath + "\\ConfigFile\\" + "Params_";

        /// <summary>
        /// 获取所有的Params
        /// </summary>
        /// <param name="xmlpath">存放Param的xml文件路径</param>
        /// <returns></returns>
        public static List<Param> GetParams()
        {
            
            if (!File.Exists(pathParams)) return null;

            List<Param> listVar = new List<Param>();

            //从指定路径加载xml文档
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(pathParams);

            //获取“Params”节点
            XmlNode noodroot = xdoc.SelectSingleNode("//Params");


            //读取Root节点下所有的Param节点，封装成变量对象，存入集合
            foreach (XmlNode nood in noodroot.ChildNodes)
            {
                if (nood.Name == "Param")
                {
                    //封装变量对象
                    Param p = new Param
                    {
                        
                        ParamName = GetValueByAttribute(nood, "ParamName"),
                        ValueLower = Convert.ToSingle(GetValueByAttribute(nood, "ValueLower")),
                        ValueUpper = Convert.ToSingle(GetValueByAttribute(nood, "ValueUpper")),
                        IsDetected= GetValueByAttribute(nood, "IsDetected"),
                        ModubsAddr= GetValueByAttribute(nood, "ModubsAddr"),
                        Note= GetValueByAttribute(nood, "Note")
                    };

                    listVar.Add(p);
                }
            }

            return listVar;
        }

        public static List<Param> GetParamsByType(string type)
        {
            string path = pathCommon + type + ".xml";

            if (!File.Exists(path)) return null;

            List<Param> listVar = new List<Param>();

            //从指定路径加载xml文档
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);

            //获取“Params”节点
            XmlNode noodroot = xdoc.SelectSingleNode("//Params");


            //读取Root节点下所有的Param节点，封装成变量对象，存入集合
            foreach (XmlNode nood in noodroot.ChildNodes)
            {
                if (nood.Name == "Param")
                {
                    //封装变量对象
                    Param p = new Param
                    {
                        ParamName = GetValueByAttribute(nood, "ParamName"),
                        ValueLower = Convert.ToSingle(GetValueByAttribute(nood, "ValueLower")),
                        ValueUpper = Convert.ToSingle(GetValueByAttribute(nood, "ValueUpper")),
                        IsDetected = GetValueByAttribute(nood, "IsDetected"),
                        ModubsAddr = GetValueByAttribute(nood, "ModubsAddr"),
                        Note = GetValueByAttribute(nood, "Note")
                    };

                    listVar.Add(p);
                }
            }

            return listVar;
        }

        public static bool SaveParamsByType(List<Param> listP,string type)
        {
            try
            {
                string path = pathCommon + type + ".xml";

                XmlDocument xmldoc = new XmlDocument();
                //创建第一行描述信息
                XmlDeclaration dec = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmldoc.AppendChild(dec);
                //创建根节点
                XmlElement rootnode = xmldoc.CreateElement("Params");
                //给根节点添加子节点(变量)
                foreach (Param item in listP)
                {
                    //子节点名称
                    XmlElement xmle = xmldoc.CreateElement("Param");
                    //给该节点添加属性
                    AppendAttribute(xmldoc, "ParamName", item.ParamName, xmle);
                    AppendAttribute(xmldoc, "ValueUpper", item.ValueUpper.ToString(), xmle);
                    AppendAttribute(xmldoc, "ValueLower", item.ValueLower.ToString(), xmle);
                    AppendAttribute(xmldoc, "IsDetected", item.IsDetected, xmle);
                    AppendAttribute(xmldoc, "Note", item.Note, xmle);
                    AppendAttribute(xmldoc, "ModubsAddr", item.ModubsAddr, xmle);

                    rootnode.AppendChild(xmle);

                }
                xmldoc.AppendChild(rootnode);

                if (File.Exists(path)) File.Delete(path);
                xmldoc.Save(path);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// 节点属性信息,根据节点及节点名称获取相应的Value
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        /// <param name="head"></param>
        public static string GetValueByAttribute(XmlNode nood, string attributeName)
        {

            if (nood != null && nood.Attributes[attributeName] != null)
            {
                return nood.Attributes[attributeName].Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 给节点添加属性信息
        /// </summary>
        /// <param name="xmlDoc">xml文档对象</param>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        /// <param name="element"></param>
        public static void AppendAttribute(XmlDocument xmlDoc, string name, string value, XmlElement element)
        {
            XmlAttribute att = xmlDoc.CreateAttribute(name);
            att.Value = value;
            element.Attributes.Append(att);
        }
    }
}
