﻿using System.Web;
using System.Web.Optimization;

namespace Jardines2022.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new Bundle("~/bundles/complementos").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.responsive.js",
                "~/Scripts/loadingoverlay.min.js",
                "~/Scripts/sweetalert.min.js",
                "~/Scripts/fontawesome/all.min.js",
                "~/Scripts/scripts.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //          "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/DataTables/css/jquery.dataTables.css",
                 "~/Content/DataTables/css/responsive.dataTables.css",
                 "~/Content/bootstrap.css",
                 "~/Content/sweetalert.css",
                 "~/Content/PagedList.css",
                 "~/Content/site.css"));
        }
    }
}
