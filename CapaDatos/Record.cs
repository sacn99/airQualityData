using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Record
    {
        private String fecha { get; set; }
        private String autoridad_ambiental { get; set; }
        private String nombre_de_la_estaci_n { get; set; }
        private String tecnolog_a { get; set; }
        private String latitud { get; set; }
        private String longitud { get; set; }
        private String c_digo_del_departamento { get; set; }
        private String departamento { get; set; }
        private String c_digo_del_municipio { get; set; }
        private String nombre_del_municipio { get; set; }
        private String tipo_de_estaci_n { get; set; }
        private String tiempo_de_exposici_n { get; set; }
        private String variable { get; set; }
        private String unidades { get; set; }
        private String concentraci_n { get; set; }
        private String geocoded_column { get; set; }

        public Record(String fecha, String autoridad_ambiental, String nombre_de_la_estaci_n, String tecnolog_a, String latitud, String longitud, String c_digo_del_departamento, String departamento, String c_digo_del_municipio, String nombre_del_municipio, String tipo_de_estaci_n, String tiempo_de_exposici_n, String variable, String unidades, String concentraci_n, String geocoded_column)
        {
            this.fecha = fecha;
            this.autoridad_ambiental = autoridad_ambiental;
            this.nombre_de_la_estaci_n = nombre_de_la_estaci_n;
            this.tecnolog_a = tecnolog_a;
            this.latitud = latitud;
            this.longitud = longitud;
            this.c_digo_del_departamento = c_digo_del_departamento;
            this.departamento = departamento;
            this.c_digo_del_municipio = c_digo_del_municipio;
            this.nombre_del_municipio = nombre_del_municipio;
            this.tipo_de_estaci_n = tipo_de_estaci_n;
            this.tiempo_de_exposici_n = tiempo_de_exposici_n;
            this.variable = variable;
            this.unidades = unidades;
            this.concentraci_n = concentraci_n;
            this.geocoded_column = geocoded_column;
        }

    }
}
