using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OutputExcel
{
    /// <summary>
    ///
    /// author:dodo
    /// 网址：www.xueit.com
    ///
    /// 读取XML类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class xmlHepler<T>
    {
        Hashtable table = new Hashtable();
        T FileName;
        T Root;    //根节点
        T RootAttName; //节点属性名称
        T RootAttValue; //根节点属性值
        T Field;       //Xml字段
        /// <summary>
        /// XML文件路径
        /// </summary>
        /// <param name="val"></param>
        public xmlHepler(T val)
        {
            FileName = val;
            this.LoadXml(val.ToString());
        }

        /// <summary>
        /// XML文件路径
        /// </summary>
        /// <param name="file"></param>
        private void LoadXml(string file)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(file);
            table.Add("xml", xdoc);
        }

        /// <summary>
        /// 返回XML to DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetXmlToDataTable()
        {
            string[] SplitField = Field.ToString().Split(',');
            //构造DataTable
            DataTable dt = new DataTable();
            DataColumn dc = null;
            for (int i = 0; i < SplitField.Length; i++)
            {
                dc = new DataColumn(SplitField[i]);
                dt.Columns.Add(dc);
            }
            XmlDocument xdoc = (XmlDocument)table["xml"];
            XmlNodeList xTable = xdoc.DocumentElement.SelectNodes(Root.ToString());

            foreach (XmlNode xnode in xTable)
            {
                if (xnode.Attributes[RootAttName.ToString()].InnerText == RootAttValue.ToString()) //某一节点
                {
                    //该节点下所有子节点
                    XmlNodeList xnlist = xnode.ChildNodes;
                    //子节点所有数据
                    for (int i = 0; i < xnlist.Count; i++)  //for (int i = 0; i < xnode.ChildNodes.Count; i  ) 这句是所有xml子节点数据
                    {
                        DataRow dr = dt.NewRow();
                        //绑定所需字段
                        for (int j = 0; j < SplitField.Length; j++)
                        {
                            dr[SplitField[j]] = xnode.ChildNodes[i].Attributes[SplitField[j]].Value;
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 返回xml 节点内容
        /// </summary>
        /// <returns></returns>
        public string GetXmlToString()
        {
            string strText = string.Empty;
            XmlDocument xdoc = (XmlDocument)table["xml"];
            XmlNodeList xnList = xdoc.DocumentElement.SelectNodes(Root.ToString());

            foreach (XmlNode xnode in xnList)
            {
                if (xnode.Attributes[RootAttName.ToString()].InnerText == RootAttValue.ToString())
                {
                    strText = xnode.Attributes[Field.ToString()].InnerText;
                    break;
                }
            }

            return strText;
        }

        #region 设置值
        /// <summary>
        /// 根节点
        /// </summary>
        public T xmlRoot
        {
            get { return Root; }
            set { Root = value; }
        }
        /// <summary>
        /// 节点属性字段名称
        /// </summary>
        public T xmlRootAttName
        {
            get { return RootAttName; }
            set { RootAttName = value; }
        }
        /// <summary>
        /// 节点属性字段值
        /// </summary>
        public T xmlRootAttValue
        {
            get { return RootAttValue; }
            set { RootAttValue = value; }
        }

        /// <summary>
        /// 子节点属性字段
        /// </summary>
        public T xmlSplitField
        {
            set { Field = value; }
        }
        #endregion
    }
   
}
