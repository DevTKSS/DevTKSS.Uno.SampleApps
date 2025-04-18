using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UnoHotDesignApp1.GeneralModels;
public record SampleCode(string? cSharpCode, string? xamlCode)
{
}
[JsonSerializable(typeof(SampleCode))]
public partial class SampleCodeContext : JsonSerializerContext 
{
}
