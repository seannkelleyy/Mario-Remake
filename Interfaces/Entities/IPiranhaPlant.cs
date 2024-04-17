using Mario.Entities.Abstract;

namespace Mario.Interfaces.Entities
{
    public interface IPiranhaPlant
    {
        /// Method to make the Piranha Plant emerge from the pipe.
        void Emerge();

        /// Method to make the Piranha Plant retract back into the pipe.
        void Retract();

        /// Method to trigger the Piranha Plant to perform a bite attack.
        void Bite();

        /// Checks if the Piranha Plant is currently hidden inside the pipe.
        /// <returns>True if the Piranha Plant is hidden, false otherwise.</returns>
        bool IsHidden();

        /// Property to get the current state of the Piranha Plant.
        AbstractEntityState CurrentState { get; }
    }
}
