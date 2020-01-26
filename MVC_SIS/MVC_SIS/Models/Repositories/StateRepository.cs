using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class StateRepository
    {
        private static List<State> _states;

        static StateRepository()
        {
            // sample data
            _states = new List<State>
            {
                new State { StateAbbreviation="KY", StateName="Kentucky" },
                new State { StateAbbreviation="MN", StateName="Minnesota" },
                new State { StateAbbreviation="OH", StateName="Ohio" },
            };
        }

        public static IEnumerable<State> GetAll()
        {
            return _states.OrderBy(s=> s.StateAbbreviation);
        }

        public static State Get(string stateAbbreviation)
        {
            return _states.FirstOrDefault(c => c.StateAbbreviation == stateAbbreviation);
        }

        public static void Add(State state)
        {
            _states.Add(state);
        }

        public static void Edit(State state)
        {
            _states.RemoveAll(c => c.StateAbbreviation == state.StateAbbreviation);

            _states.Add(state);
        }

        public static void Delete(string stateAbbreviation)
        {
            _states.RemoveAll(c => c.StateAbbreviation == stateAbbreviation);
        }
    }
}