namespace Engine.Models
{
    public class World
    {
        private readonly List<Location> _locations = [];

        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            Location newLocation = new()
            {
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate,
                Name = name,
                Description = description,
                ImageName = imageName
            };

            _locations.Add(newLocation);
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (Location newLocation in _locations)
            {
                if (newLocation.XCoordinate == xCoordinate && newLocation.YCoordinate == yCoordinate)
                {
                    return newLocation;
                }
            }
            return null;
        }
    }
}
