﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;

namespace GISManager
{
    public class GISHandler
    {
        //定义栅格打开函数
        public static void OpenRaster(string rasterFileName, AxMapControl _MapControl)
        {
            if (!File.Exists(rasterFileName))
            {
                return;
            }
            if (_MapControl == null)
            {
                return;
            }
            try
            {
                //文件名处理
                string ws = System.IO.Path.GetDirectoryName(rasterFileName);
                string fbs = System.IO.Path.GetFileName(rasterFileName);
                //创建工作空间
                IWorkspaceFactory pWork = new RasterWorkspaceFactoryClass();
                //打开工作空间路径，工作空间的参数是目录，不是具体的文件名
                IRasterWorkspace pRasterWS = (IRasterWorkspace)pWork.OpenFromFile(ws, 0);
                //打开工作空间下的文件，
                IRasterDataset pRasterDataset = pRasterWS.OpenRasterDataset(fbs);
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromDataset(pRasterDataset);
                //添加到图层控制中
                _MapControl.Map.AddLayer(pRasterLayer as ILayer);
            }
            catch { }
        }

        public static bool IsSupportLayerType(string extension)
        {
            bool isSupport = false;
            if (extension == ".img" || extension == ".tif" || extension == ".shp" || extension == ".mm" || extension == ".mxd")
            {
                isSupport = true;
            }
            return isSupport;
        }

        public static ILayer GetLayerFromTOCControl(AxTOCControl _axTOCControl)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object legendGroup = new object();
            object index = new object();
            esriTOCControlItem item = new esriTOCControlItem();

            _axTOCControl.GetSelectedItem(ref item, ref map, ref layer, ref legendGroup, ref index);
            return layer;
        }
        //投影转换
        public static void TestProjection(ILayer layer)
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            var srf = obj as ISpatialReferenceFactory3;

            // Create Transformation from WGS84 to WGS1972
            var geoTrans = srf.CreateGeoTransformation((int)esriSRGeoTransformationType.esriSRGeoTransformation_WGS1972_To_WGS1984_1) as IGeoTransformation;

            ISpatialReference fromSpatialReference;
            ISpatialReference toSpatialReference;
            geoTrans.GetSpatialReferences(out fromSpatialReference, out toSpatialReference);

            var wgs84GCS = srf.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            //var bngPCS = srf.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_BritishNationalGrid);
            //if ((wgs84GCS.FactoryCode != toSpatialReference.FactoryCode)
            //    || (bngPCS.GeographicCoordinateSystem.FactoryCode != fromSpatialReference.FactoryCode))
            //{
            //    //throw new System.Exception("invalid geotransformation");
            //    return;
            //}
            layer.SpatialReference = wgs84GCS;

            //IGeometry5 geometry;
            //IPoint point = new PointClass();
            //point.PutCoords(-3.159875, 51.465615);
            //geometry = point as IGeometry5;
            //geometry.SpatialReference = wgs84GCS;

            //geometry.ProjectEx(bngPCS, esriTransformDirection.esriTransformReverse, geoTrans, false, 0.0, 0.0);
            //point = geometry as IPoint;
            //Debug.Print("{0} {1}", point.X, point.Y);
        }
        /// <summary>
        /// 获得选中的要素ICurse
        /// </summary>
        /// <param name="_featureLayer">IFeatureLayer</param>
        /// <returns>ICursor</returns>
        public static ICursor GetSelectionFeature(IFeatureLayer _featureLayer)
        {
            IFeatureSelection featureSelection = _featureLayer as IFeatureSelection;
            ISelectionSet selectionSet = featureSelection.SelectionSet;

            ICursor cursor = null;
            try
            {
                selectionSet.Search(null, false, out cursor);

                //IRow row = cursor.NextRow();
                //while (row != null)
                //{
                //    IFeature feature = (IFeature)row;
                //    ITable table = row.Table;
                //    int nameIndex = table.FindField("PAC");
                //    if (nameIndex > 0)
                //    {
                //        string value = (string)feature.get_Value(nameIndex);
                //        MessageBox.Show(value);
                //        break;
                //    }
                //}
            }
            catch { }
            return cursor;

        }

        /// <summary>
        /// 获得选中的要素DataTable
        /// </summary>
        /// <param name="_featureLayer">IFeatureLayer</param>
        /// <returns>ICursor</returns>
        public static DataTable GetFeatureAttr(IFeatureLayer _featureLayer)
        {
            DataTable dt = new DataTable();
            IFeatureSelection featureSelection = _featureLayer as IFeatureSelection;
            ISelectionSet selectionSet = featureSelection.SelectionSet;

            ICursor cursor = null;
            try
            {
                selectionSet.Search(null, false, out cursor);

                //IRow row = cursor.NextRow();
                //while (row != null)
                //{
                //    IFeature feature = (IFeature)row;
                //    ITable table = row.Table;
                //    int nameIndex = table.FindField("PAC");
                //    if (nameIndex > 0)
                //    {
                //        string value = (string)feature.get_Value(nameIndex);
                //        MessageBox.Show(value);
                //        break;
                //    }
                //}
            }
            catch { }
            return dt;

        }
        /// <summary>
        /// 获取选中要素的DataTable
        /// </summary>
        /// <param name="pSelection">IFeature</param>
        /// <returns>DataTable</returns>
        public static DataTable GetFeatureAttr(IFeature pFeature)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", System.Type.GetType("System.String"));  //名称
            dt.Columns.Add("value", System.Type.GetType("System.String"));  //值
            try
            {
                if (pFeature == null)
                {
                    return dt;
                }
                ITable table = pFeature.Table;
                IFields fields = table.Fields;
                for (int i = 0; i < fields.FieldCount;i++)
                {
                    //获取数据
                    IField field = fields.get_Field(i);
                    string aliasName = field.AliasName;
                    string name = GISConfig.ConvertFieldName(aliasName);
                    if (name == "")
                    {
                        continue;
                    }
                    string value = Convert.ToString(pFeature.get_Value(i));
                    //写入数据
                    DataRow dr = dt.NewRow();
                    dr["name"] = name;
                    dr["value"] = value;
                    dt.Rows.Add(dr);
                }
            }
            catch { }
            return dt;
        }

        /// <summary>
        /// 获取第一个选中的要素
        /// </summary>
        /// <param name="pSelection">ISelection</param>
        /// <returns>IFeature</returns>
        public static IFeature GetFirstSelectionFeature(AxMapControl _axMapControl)
        {
            IFeature pFeature = null;
            try
            {
                ISelection pSelection = _axMapControl.Map.FeatureSelection;
                
                // 打开属性标签
                IEnumFeatureSetup pEnumFeatureSetup = pSelection as IEnumFeatureSetup;                
                pEnumFeatureSetup.AllFields = true;
                // 读取属性           
                IEnumFeature pEnumFeature = pSelection as IEnumFeature;
               
                pFeature = pEnumFeature.Next();
            }
            catch { }
            return pFeature;
        }

        /// <summary>
        /// 获取第一个选中的要素的属性表
        /// </summary>
        /// <param name="pSelection">ISelection</param>
        /// <returns>IFeature</returns> 
        public static DataTable GetFirstSelectionFeatureAttr(AxMapControl _axMapControl)
        {
            DataTable dt = new DataTable();
            IFeature pFeature = GetFirstSelectionFeature(_axMapControl);
            if (pFeature != null)
            {
                dt = GetFeatureAttr(pFeature);
            }            
            return dt;
        }
        

    }
}
