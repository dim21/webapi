using System;
using WebApi.Models.Base;

namespace WebApi.Models.Todos
{
    public class TodoInfo : IEntityBase<Guid>
    {
        public TodoInfo(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        /// <inheritdoc />
        public void SetNewId()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc />
        public void Patch(IEntityBase<Guid> other)
        {
            Patch((TodoInfo) other);
        }

        /// <inheritdoc />
        public string CheckPost()
        {
            if (string.IsNullOrEmpty(Type)) return "Invalid type";
            if (string.IsNullOrEmpty(Title)) return "Title is missing";
            if (string.IsNullOrEmpty(Text)) return "Text is missing";
            return null;
        }

        private void Patch(TodoInfo other)
        {
            if (!string.IsNullOrEmpty(other.Type)) Type = other.Type;
            if (!string.IsNullOrEmpty(other.Text)) Text = other.Text;
            if (!string.IsNullOrEmpty(other.Title)) Title = other.Title;
        }
    }
}