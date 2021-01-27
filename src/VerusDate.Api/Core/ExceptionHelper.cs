﻿using Microsoft.Azure.Cosmos;
using System;
using System.Linq;
using System.Text.Json;

namespace VerusDate.Api.Core
{
    public class CosmosExceptionStructure
    {
        public string[] Errors { get; set; }
    }

    public static class ExceptionHelper
    {
        public static string ProcessException(this Exception ex)
        {
            if (ex is CosmosException cex)
            {
                var result = JsonSerializer.Deserialize<CosmosExceptionStructure>(cex.ResponseBody);

                return result.Errors.FirstOrDefault();
            }
            else
            {
                return ex.Message;
            }
        }
    }
}