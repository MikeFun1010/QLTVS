using System.Collections.Generic;

namespace QLTVS
{
    // Renamed to avoid colliding with QLTVS.class_test_.Book
    public class MockBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Available { get; set; }
    }

    // Renamed to avoid colliding with any Member/DTO classes
    public class MockMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class MockRepository
    {
        public static List<MockBook> Books { get; } = new List<MockBook>
        {
            new MockBook { Id = 1, Title = "Clean Code", Available = 3 },
            new MockBook { Id = 2, Title = "The Pragmatic Programmer", Available = 2 },
            new MockBook { Id = 3, Title = "Design Patterns", Available = 1 },
        };

        public static List<MockMember> Members { get; } = new List<MockMember>
        {
            new MockMember { Id = 1, Name = "Alice" },
            new MockMember { Id = 2, Name = "Bob" },
            new MockMember { Id = 3, Name = "Charlie" },
        };
    }
}