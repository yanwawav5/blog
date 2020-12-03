namespace Blog.Dto.Blog
{
    public class CommentAddDto
    {
        public string BlogId { get; set; }
        public string Content { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int CurrentFloorNum { get; set; }
        public int? ToFloorNum { get; set; }
    }
}
