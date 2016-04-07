﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Interfaced;
using Akka.Actor;
using ProtoBuf;
using TypeAlias;
using System.ComponentModel;

#region Domain.IGame

namespace Domain
{
    [PayloadTableForInterfacedActor(typeof(IGame))]
    public static class IGame_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Enter_Invoke), typeof(Enter_Return) },
                { typeof(Leave_Invoke), null },
            };
        }

        [ProtoContract, TypeAlias]
        public class Enter_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.String userId;
            [ProtoMember(2)] public Domain.GameObserver observer;
            public Type GetInterfaceType() { return typeof(IGame); }
            public async Task<IValueGetable> InvokeAsync(object target)
            {
                var __v = await ((IGame)target).Enter(userId, observer);
                return (IValueGetable)(new Enter_Return { v = (System.Tuple<System.Int32, Domain.GameInfo>)__v });
            }
        }

        [ProtoContract, TypeAlias]
        public class Enter_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Tuple<System.Int32, Domain.GameInfo> v;
            public Type GetInterfaceType() { return typeof(IGame); }
            public object Value { get { return v; } }
        }

        [ProtoContract, TypeAlias]
        public class Leave_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.String userId;
            public Type GetInterfaceType() { return typeof(IGame); }
            public async Task<IValueGetable> InvokeAsync(object target)
            {
                await ((IGame)target).Leave(userId);
                return null;
            }
        }
    }

    public interface IGame_NoReply
    {
        void Enter(System.String userId, Domain.IGameObserver observer);
        void Leave(System.String userId);
    }

    [ProtoContract, TypeAlias]
    public class GameRef : InterfacedActorRef, IGame, IGame_NoReply
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private GameRef() : base(null)
        {
        }

        public GameRef(IActorRef actor) : base(actor)
        {
        }

        public GameRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout) : base(actor, requestWaiter, timeout)
        {
        }

        public IGame_NoReply WithNoReply()
        {
            return this;
        }

        public GameRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new GameRef(Actor, requestWaiter, Timeout);
        }

        public GameRef WithTimeout(TimeSpan? timeout)
        {
            return new GameRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Tuple<System.Int32, Domain.GameInfo>> Enter(System.String userId, Domain.IGameObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGame_PayloadTable.Enter_Invoke { userId = userId, observer = (Domain.GameObserver)observer }
            };
            return SendRequestAndReceive<System.Tuple<System.Int32, Domain.GameInfo>>(requestMessage);
        }

        public Task Leave(System.String userId)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGame_PayloadTable.Leave_Invoke { userId = userId }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IGame_NoReply.Enter(System.String userId, Domain.IGameObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGame_PayloadTable.Enter_Invoke { userId = userId, observer = (Domain.GameObserver)observer }
            };
            SendRequest(requestMessage);
        }

        void IGame_NoReply.Leave(System.String userId)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGame_PayloadTable.Leave_Invoke { userId = userId }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion
#region Domain.IGameClient

namespace Domain
{
    [PayloadTableForInterfacedActor(typeof(IGameClient))]
    public static class IGameClient_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(ZoneChange_Invoke), null },
            };
        }

        [ProtoContract, TypeAlias]
        public class ZoneChange_Invoke
            : IInterfacedPayload, ITagOverridable, IAsyncInvokable
        {
            [ProtoMember(1)] public System.String senderUserId;
            [ProtoMember(2)] public System.Byte[] bytes;
            public Type GetInterfaceType() { return typeof(IGameClient); }
            public void SetTag(object value) { senderUserId = (System.String)value; }
            public async Task<IValueGetable> InvokeAsync(object target)
            {
                await ((IGameClient)target).ZoneChange(senderUserId, bytes);
                return null;
            }
        }
    }

    public interface IGameClient_NoReply
    {
        void ZoneChange(System.String senderUserId, System.Byte[] bytes);
    }

    [ProtoContract, TypeAlias]
    public class GameClientRef : InterfacedActorRef, IGameClient, IGameClient_NoReply
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private GameClientRef() : base(null)
        {
        }

        public GameClientRef(IActorRef actor) : base(actor)
        {
        }

        public GameClientRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout) : base(actor, requestWaiter, timeout)
        {
        }

        public IGameClient_NoReply WithNoReply()
        {
            return this;
        }

        public GameClientRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new GameClientRef(Actor, requestWaiter, Timeout);
        }

        public GameClientRef WithTimeout(TimeSpan? timeout)
        {
            return new GameClientRef(Actor, RequestWaiter, timeout);
        }

        public Task ZoneChange(System.String senderUserId, System.Byte[] bytes)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGameClient_PayloadTable.ZoneChange_Invoke { senderUserId = senderUserId, bytes = bytes }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IGameClient_NoReply.ZoneChange(System.String senderUserId, System.Byte[] bytes)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGameClient_PayloadTable.ZoneChange_Invoke { senderUserId = senderUserId, bytes = bytes }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion
#region Domain.IUser

namespace Domain
{
    [PayloadTableForInterfacedActor(typeof(IUser))]
    public static class IUser_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(EnterGame_Invoke), typeof(EnterGame_Return) },
                { typeof(GetId_Invoke), typeof(GetId_Return) },
                { typeof(LeaveGame_Invoke), null },
            };
        }

        [ProtoContract, TypeAlias]
        public class EnterGame_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.String name;
            [ProtoMember(2)] public System.Int32 observerId;
            public Type GetInterfaceType() { return typeof(IUser); }
            public async Task<IValueGetable> InvokeAsync(object target)
            {
                var __v = await ((IUser)target).EnterGame(name, observerId);
                return (IValueGetable)(new EnterGame_Return { v = (System.Tuple<System.Int32, System.Int32, Domain.GameInfo>)__v });
            }
        }

        [ProtoContract, TypeAlias]
        public class EnterGame_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Tuple<System.Int32, System.Int32, Domain.GameInfo> v;
            public Type GetInterfaceType() { return typeof(IUser); }
            public object Value { get { return v; } }
        }

        [ProtoContract, TypeAlias]
        public class GetId_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType() { return typeof(IUser); }
            public async Task<IValueGetable> InvokeAsync(object target)
            {
                var __v = await ((IUser)target).GetId();
                return (IValueGetable)(new GetId_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class GetId_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.String v;
            public Type GetInterfaceType() { return typeof(IUser); }
            public object Value { get { return v; } }
        }

        [ProtoContract, TypeAlias]
        public class LeaveGame_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType() { return typeof(IUser); }
            public async Task<IValueGetable> InvokeAsync(object target)
            {
                await ((IUser)target).LeaveGame();
                return null;
            }
        }
    }

    public interface IUser_NoReply
    {
        void EnterGame(System.String name, System.Int32 observerId);
        void GetId();
        void LeaveGame();
    }

    [ProtoContract, TypeAlias]
    public class UserRef : InterfacedActorRef, IUser, IUser_NoReply
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private UserRef() : base(null)
        {
        }

        public UserRef(IActorRef actor) : base(actor)
        {
        }

        public UserRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout) : base(actor, requestWaiter, timeout)
        {
        }

        public IUser_NoReply WithNoReply()
        {
            return this;
        }

        public UserRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserRef(Actor, requestWaiter, Timeout);
        }

        public UserRef WithTimeout(TimeSpan? timeout)
        {
            return new UserRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Tuple<System.Int32, System.Int32, Domain.GameInfo>> EnterGame(System.String name, System.Int32 observerId)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.EnterGame_Invoke { name = name, observerId = observerId }
            };
            return SendRequestAndReceive<System.Tuple<System.Int32, System.Int32, Domain.GameInfo>>(requestMessage);
        }

        public Task<System.String> GetId()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.GetId_Invoke {  }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task LeaveGame()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.LeaveGame_Invoke {  }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IUser_NoReply.EnterGame(System.String name, System.Int32 observerId)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.EnterGame_Invoke { name = name, observerId = observerId }
            };
            SendRequest(requestMessage);
        }

        void IUser_NoReply.GetId()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.GetId_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void IUser_NoReply.LeaveGame()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.LeaveGame_Invoke {  }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion
#region Domain.IGameObserver

namespace Domain
{
    public static class IGameObserver_PayloadTable
    {
        [ProtoContract, TypeAlias]
        public class Enter_Invoke : IInvokable
        {
            [ProtoMember(1)] public System.String userId;
            public void Invoke(object target)
            {
                ((IGameObserver)target).Enter(userId);
            }
        }

        [ProtoContract, TypeAlias]
        public class Leave_Invoke : IInvokable
        {
            [ProtoMember(1)] public System.String userId;
            public void Invoke(object target)
            {
                ((IGameObserver)target).Leave(userId);
            }
        }

        [ProtoContract, TypeAlias]
        public class ZoneChange_Invoke : IInvokable
        {
            [ProtoMember(1)] public System.Byte[] bytes;
            public void Invoke(object target)
            {
                ((IGameObserver)target).ZoneChange(bytes);
            }
        }
    }

    [ProtoContract, TypeAlias]
    public class GameObserver : InterfacedObserver, IGameObserver
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return Channel != null ? (ActorRefBase)(((ActorNotificationChannel)Channel).Actor) : null; }
            set { Channel = new ActorNotificationChannel(value); }
        }

        [ProtoMember(2)] private int _observerId
        {
            get { return ObserverId; }
            set { ObserverId = value; }
        }

        private GameObserver() : base(null, 0)
        {
        }

        public GameObserver(IActorRef target, int observerId)
            : base(new ActorNotificationChannel(target), observerId)
        {
        }

        public GameObserver(INotificationChannel channel, int observerId)
            : base(channel, observerId)
        {
        }

        public void Enter(System.String userId)
        {
            var payload = new IGameObserver_PayloadTable.Enter_Invoke { userId = userId };
            Notify(payload);
        }

        public void Leave(System.String userId)
        {
            var payload = new IGameObserver_PayloadTable.Leave_Invoke { userId = userId };
            Notify(payload);
        }

        public void ZoneChange(System.Byte[] bytes)
        {
            var payload = new IGameObserver_PayloadTable.ZoneChange_Invoke { bytes = bytes };
            Notify(payload);
        }
    }
}

#endregion
