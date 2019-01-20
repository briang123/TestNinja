﻿using Newtonsoft.Json;
using System.Data.Entity;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _repository;

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _repository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);

            return video == null ? "Error parsing the video." : video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videos = _repository.GetUnprocessedVideos();
            var videoIds = videos.Select(v => v.Id).ToList();

            return string.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}