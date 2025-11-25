using System;
using System.Collections.Generic;

namespace QLTVS_API.Models;

public partial class Theloai
{
    public string Matheloai { get; set; } = null!;

    public string Tentheloai { get; set; } = null!;

    public virtual ICollection<Tailieu> Tailieus { get; set; } = new List<Tailieu>();
}
