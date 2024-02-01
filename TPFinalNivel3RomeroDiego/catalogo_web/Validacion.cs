﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public class Validacion
    {
        public static bool validarTextoVacio(object control)
        {
            if(control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}