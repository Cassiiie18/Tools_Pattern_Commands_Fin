using Models.Entities;
using Models.Repositories;
using Tools.Pattern.Commands;

namespace Models.Services
{
    public class PersonneService : IPersonneRepository
    {
        private IList<Personne> _items;

        public PersonneService() 
        {
            _items = new List<Personne>();
        }

        public IEnumerable<Personne> Get()
        {
            return _items;
        }

        public Personne? Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Personne personne)
        {
            ICommand command = new RelayCommand(() => Add(personne));
            command.Execute();
        }

        private void Add(Personne personne)
        {
            personne.Id = _items.Count == 0 ? 1 : _items.Max(p => p.Id) + 1;
            _items.Add(personne);
        }

        public void Delete(int id)
        {
            ICommand command = new RelayCommand(() =>
            {
                Personne? personne = _items.SingleOrDefault(p => p.Id == id);
                if (personne is null) return;
                _items.Remove(personne);
            });

            command.Execute();
        }
    }
}
