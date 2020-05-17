using System;
using System.Collections.Generic;

public class StateMachine
{
    public State CurrentState
    {
        get;
        private set;
    }

    public State PreviousState
    {
        get;
        private set;
    }

    private List<State> _possibleStates;
    private List<StateTransition> _possibleTransitions;

    private bool ExistStateWithIdentifier(int identifier)
    {
        foreach (var state in _possibleStates)
        {
            if (state.Identifier == identifier)
            {
                return true;
            }
        }

        return false;
    }
    
    private StateTransition GetStateTransitionWithIdentifiers(int origin, int destination)
    {
        if (!ExistStateWithIdentifier(origin) || !ExistStateWithIdentifier(destination))
        {
            return null;
        }

        foreach (var transition in _possibleTransitions)
        {
            if (transition.Origin.Identifier == origin &&
                transition.Destination.Identifier == destination)
            {
                return transition;
            }
        }

        return null;
    }

    public void AddState(int stateIdentifier)
    {
        AddState(new State(stateIdentifier));
    }

    public void AddState(State state)
    {
        if (ExistStateWithIdentifier(state.Identifier))
        {
            throw new Exception("Trying to add state duplicate");
        }
        _possibleStates.Add(state);

        if (_possibleStates.Count == 1)
        {
            CurrentState = state;
            PreviousState = state;
        }
    }

    public void AddStateTransition(int originIdentifier, int destinationIdentifier, Action onTransit)
    {
        AddStateTransition(new StateTransition(originIdentifier, destinationIdentifier, onTransit));
    }

    public void AddStateTransition(StateTransition transition)
    {
        if (!ExistStateWithIdentifier(transition.Origin.Identifier) ||
            !ExistStateWithIdentifier(transition.Destination.Identifier))
        {
            throw new Exception("Cannot add transition to/from missing state");
        }
        
        _possibleTransitions.Add(transition);
    }

    public void TransitTo(int destination)
    {
        if (!ExistStateWithIdentifier(destination))
        {
            throw new Exception("Cannot transit to missing state");
        }

        var transition = GetStateTransitionWithIdentifiers(CurrentState.Identifier, destination);

        if (transition == null)
        {
            throw new Exception("Cannot transit to state without a explicit transition defined");
        }

        PreviousState = CurrentState;
        CurrentState = transition.Destination;
        transition.OnTransit?.Invoke();
    }
    

    public class State
    {
        public int Identifier { get; }

        public State(int identifier)
        {
            Identifier = identifier;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(State))
            {
                return false;
            }

            var anotherState = (State) obj;

            return Identifier == anotherState.Identifier;
        }
    }

    public class StateTransition
    {
        public State Origin { get; }
        public State Destination { get; }

        public Action OnTransit { get; }

        public StateTransition(State origin, State destination, Action onTransit)
        {
            Origin = origin;
            Destination = destination;
            OnTransit = onTransit;
        }

        public StateTransition(int origin, int destination, Action onTransit) :
            this(new State(origin), new State(destination), onTransit)
        { }
    }
}
