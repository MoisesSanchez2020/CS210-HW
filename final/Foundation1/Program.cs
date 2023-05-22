using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Create videos
        Video video1 = new Video("Video 1", "Author 1", 120);
        Video video2 = new Video("Video 2", "Author 2", 180);

        // Add comments to videos
        video1.Comments.Add(new Comment("User1", "Comment 1 for video 1"));
        video1.Comments.Add(new Comment("User2", "Comment 2 for video 1"));
        video2.Comments.Add(new Comment("User3", "Comment 1 for video 2"));
        video2.Comments.Add(new Comment("User4", "Comment 2 for video 2"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);

        // Display video information and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
