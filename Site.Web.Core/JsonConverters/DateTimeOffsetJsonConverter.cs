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
    /// 时间类型为 DateTimeOffset，自动序列化
    /// </summary>
    [SuppressSniffer]
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="format">默认格式</param>
        public DateTimeOffsetJsonConverter(string format = "yyyy-MM-dd HH:mm:ss")
        {
            Format = format;
        }

        /// <summary>
        /// 时间格式化格式
        /// </summary>
        public string Format { get; private set; }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(Format))
            {
                writer.WriteStringValue(value.ToLocalTime());
            }
            else
            {
                writer.WriteStringValue(value.ToLocalTime().ToString(Format));
            }
        }
    }
}
