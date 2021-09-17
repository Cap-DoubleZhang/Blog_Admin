using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Site.Web.Core
{
    /// <summary>
    /// 时间类型为 DateTime时，自动序列化
    /// </summary>
    [SuppressSniffer]
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="format"></param>
        public DateTimeJsonConverter(string format = "yyyy.MM.dd")
        {
            Format = format;
        }

        /// <summary>
        /// 时间格式化格式
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(Format))
            {
                writer.WriteStringValue(value.ToString());
            }
            else
            {
                writer.WriteStringValue(value.ToString(Format));
            }
        }
    }
}
