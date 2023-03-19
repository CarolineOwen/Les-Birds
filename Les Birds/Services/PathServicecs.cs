using Les_Birds.Options;

namespace Les_Birds.Services
{
    public class PathServicecs
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public PathServicecs(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public string GetUploadsPath(string? filename= null, bool withWebRootPath = true)
        {
            var pathOptions = new PathOptions();
            configuration.GetSection(PathOptions.Path).Bind(pathOptions);
            var uploadsPath = pathOptions.BirdsImages;
            if(null != filename)
            {
                uploadsPath = Path.Combine(uploadsPath, filename);
            }
            return withWebRootPath ? Path.Combine(env.WebRootPath, uploadsPath) : uploadsPath;
        }
    }
}
