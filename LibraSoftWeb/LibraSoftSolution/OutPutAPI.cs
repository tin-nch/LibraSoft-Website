﻿using LibraSoftSolution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API
{
    public static class OutPutApi
    {

        public static List<T> OutPut<T>(RequestResponse body)
        {
            if (body == null)
            {
                return null;
            }
            if (body.ErrorCode == 0)
            {
                try
                {
                    List<T> data = (List<T>)JsonConvert.DeserializeObject(body.Content, typeof(List<T>));

                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }
        public static bool OutPutBool<T>(RequestResponse body)
        {
            if (body == null)
            {
                return false;
            }
            if (body.ErrorCode == 0)
            {
                try
                {
                    List<T> data = (List<T>)JsonConvert.DeserializeObject(body.Content, typeof(List<T>));

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }
    }
}