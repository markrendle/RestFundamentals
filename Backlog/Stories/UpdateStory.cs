namespace Backlog.Stories
{
    using Simple.Web;
    using Simple.Web.Links;

    [UriTemplate("/stories/{Id}")]
    [LinksFrom(typeof(Story), "/stories/{Id}")]
    public class UpdateStory : IPut<Story>
    {
        public Status Put(Story input)
        {
            var story = Stories.By(this.Id);

            if (story == null)
            {
                return 404;
            }

            story.Text = input.Text;

            Stories.Update(story);
            
            return 201;
        }

        public int Id { get; set; }
    }
}