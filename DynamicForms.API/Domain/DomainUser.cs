namespace Domain
{
    public class DomainUser : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid UserAuthId { get; set; }
        public ICollection<Form> CreatedForms { get; set; }
        public ICollection<FormSubmit> FormSubmits { get; set; }
        public ICollection<PrivateFormAccessor> AccessedPrivateForms { get; set; }
    }
}
