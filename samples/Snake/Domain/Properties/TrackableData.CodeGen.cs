// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityNetwork;
using ProtoBuf;
using TrackableData;
using TypeAlias;
using System.Reflection;
using System.Runtime.Serialization;

#region ISnakeData

namespace Domain.Entity
{
    [ProtoContract]
    public partial class TrackableSnakeData : ISnakeData
    {
        [IgnoreDataMember]
        public IPocoTracker<ISnakeData> Tracker { get; set; }

        public bool Changed { get { return Tracker != null && Tracker.HasChange; } }

        ITracker ITrackable.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (IPocoTracker<ISnakeData>)value;
                Tracker = t;
            }
        }

        ITracker<ISnakeData> ITrackable<ISnakeData>.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (IPocoTracker<ISnakeData>)value;
                Tracker = t;
            }
        }

        public ITrackable GetChildTrackable(object name)
        {
            switch ((string)name)
            {
                default:
                    return null;
            }
        }

        public IEnumerable<KeyValuePair<object, ITrackable>> GetChildTrackables(bool changedOnly = false)
        {
            yield break;
        }

        public static class PropertyTable
        {
            public static readonly PropertyInfo State = typeof(ISnakeData).GetProperty("State");
            public static readonly PropertyInfo Score = typeof(ISnakeData).GetProperty("Score");
        }

        private SnakeState _State;

        [ProtoMember(1)] public SnakeState State
        {
            get
            {
                return _State;
            }
            set
            {
                if (Tracker != null && State != value)
                    Tracker.TrackSet(PropertyTable.State, _State, value);
                _State = value;
            }
        }

        private int _Score;

        [ProtoMember(2)] public int Score
        {
            get
            {
                return _Score;
            }
            set
            {
                if (Tracker != null && Score != value)
                    Tracker.TrackSet(PropertyTable.Score, _Score, value);
                _Score = value;
            }
        }
    }

    [ProtoContract]
    public class TrackableSnakeDataTrackerSurrogate
    {
        [ProtoMember(1)] public EnvelopedObject<SnakeState> State;
        [ProtoMember(2)] public EnvelopedObject<int> Score;

        public static implicit operator TrackableSnakeDataTrackerSurrogate(TrackablePocoTracker<ISnakeData> tracker)
        {
            if (tracker == null)
                return null;

            var surrogate = new TrackableSnakeDataTrackerSurrogate();
            foreach(var changeItem in tracker.ChangeMap)
            {
                switch (changeItem.Key.Name)
                {
                    case "State":
                        surrogate.State = new EnvelopedObject<SnakeState> { Value = (SnakeState)changeItem.Value.NewValue };
                        break;
                    case "Score":
                        surrogate.Score = new EnvelopedObject<int> { Value = (int)changeItem.Value.NewValue };
                        break;
                }
            }
            return surrogate;
        }

        public static implicit operator TrackablePocoTracker<ISnakeData>(TrackableSnakeDataTrackerSurrogate surrogate)
        {
            if (surrogate == null)
                return null;

            var tracker = new TrackablePocoTracker<ISnakeData>();
            if (surrogate.State != null)
                tracker.ChangeMap.Add(TrackableSnakeData.PropertyTable.State, new TrackablePocoTracker<ISnakeData>.Change { NewValue = surrogate.State.Value });
            if (surrogate.Score != null)
                tracker.ChangeMap.Add(TrackableSnakeData.PropertyTable.Score, new TrackablePocoTracker<ISnakeData>.Change { NewValue = surrogate.Score.Value });
            return tracker;
        }
    }
}

#endregion