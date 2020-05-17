using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Record
    {
        private string Fecha;

        public string getFecha() {
            return Fecha;
        }

        public void setFecha(string Nfecha) {
            Fecha = Nfecha;
        }

        private string Autoridad_ambiental;

        public string getAutoridadAmbienta()
        {
            return Autoridad_ambiental;
        }

        public void setAutoridadAmbiental(string Aa)
        {
            Autoridad_ambiental = Aa;
        }

        private string Nombre_de_la_estaci_n;

        public string getNombreEstacion()
        {
            return Nombre_de_la_estaci_n;
        }

        public void setNombreEstacion(string Nestacion)
        {
            Nombre_de_la_estaci_n = Nestacion;
        }
        
        private string Tecnolog_a;

        public string getTecnologia()
        {
            return Tecnolog_a;
        }

        public void setTecnologia(string tecno)
        {
            Tecnolog_a = tecno;
        }

        private string Latitud;

        public string getLatitud()
        {
            return Latitud;
        }

        public void setLatitud(string lati)
        {
            Latitud = lati;
        }

        private string Longitud;

        public string getLongitud()
        {
            return Longitud;
        }

        public void setLongitud(string longi)
        {
            Longitud = longi;
        }

        private string C_digo_del_departamento;

        public string getCodigoDepto()
        {
            return C_digo_del_departamento;
        }

        public void setCodigoDepto(string codigoDepto)
        {
            C_digo_del_departamento = codigoDepto;
        }

        private string Departamento;

        public string getDepto()
        {
            return Departamento;
        }

        public void setDepto(string depto)
        {
            Departamento = depto;
        }

        private string C_digo_del_municipio;

        public string getCodigoMunicipio()
        {
            return C_digo_del_municipio;
        }

        public void setCodigoMunicipio(string codigoMuni)
        {
            C_digo_del_municipio = codigoMuni;
        }

        private string Nombre_del_municipio;

        public string getNombreMuni()
        {
            return Nombre_del_municipio;
        }

        public void setNombreMuni(string nombreMuni)
        {
            Nombre_del_municipio = nombreMuni;
        }

        private string Tipo_de_estaci_n;

        public string getTipoEstacion()
        {
            return Tipo_de_estaci_n;
        }

        public void setTipoEstacion(string tipoEsta)
        {
            Tipo_de_estaci_n = tipoEsta;
        }

        private string Tiempo_de_exposici_n;

        public string getTiempoExpo()
        {
            return Tiempo_de_exposici_n;
        }

        public void setTiempoExpo(string tiempoExpo)
        {
            Tiempo_de_exposici_n = tiempoExpo;
        }

        private string Variable;

        public string getVariable()
        {
            return Variable;
        }

        public void setVariable(string var)
        {
            Variable = var;
        }

        private string Unidades;

        public string getUnidades()
        {
            return Unidades;
        }

        public void setUnidades(string uni)
        {
            Unidades = uni;
        }

        private string Concentraci_n;

        public string getConcentracion()
        {
            return Concentraci_n;
        }

        public void setConcentracion(string conc)
        {
            Concentraci_n = conc;
        }


        public Record(String fecha, String autoridad_ambiental, String nombre_de_la_estaci_n, String tecnolog_a, String latitud, String longitud, String c_digo_del_departamento, String departamento, String c_digo_del_municipio, String nombre_del_municipio, String tipo_de_estaci_n, String tiempo_de_exposici_n, String variable, String unidades, String concentraci_n)
        {
            this.Fecha = fecha;
            this.Autoridad_ambiental = autoridad_ambiental;
            this.Nombre_de_la_estaci_n = nombre_de_la_estaci_n;
            this.Tecnolog_a = tecnolog_a;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.C_digo_del_departamento = c_digo_del_departamento;
            this.Departamento = departamento;
            this.C_digo_del_municipio = c_digo_del_municipio;
            this.Nombre_del_municipio = nombre_del_municipio;
            this.Tipo_de_estaci_n = tipo_de_estaci_n;
            this.Tiempo_de_exposici_n = tiempo_de_exposici_n;
            this.Variable = variable;
            this.Unidades = unidades;
            this.Concentraci_n = concentraci_n;
        }

    }
}
