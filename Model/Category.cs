using System.ComponentModel.DataAnnotations;

namespace BlazorElectronApp.Model
{
    public class Category
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的 属性“Name”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
        public string Name { get; set; }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的 属性“Name”必须包含非 null 值。请考虑将 属性 声明为可以为 null。

        [Required, Key]

        public int ID { get; set; }
    }
}
