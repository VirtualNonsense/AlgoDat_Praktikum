using System;
using AlgoDatConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.AlgoDatConsole
{
    [TestClass]
    public class EzStateMachineTests
    {
        private enum TestState
        {
            Null,
            S0,
            S1,
            S2
        }

        private enum TestTrigger
        {
            T0,
            T1,
            T2
        }

        [TestMethod]
        public void PermitTest_AddNonExistentPermission()
        {
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);
            
            // Action
            var result = m.Permit(TestTrigger.T0, TestState.S0, TestState.S1);
            
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PermitTest_AddDuplicatePermission()
        {
            
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);
            m.Permit(TestTrigger.T0, TestState.S0, TestState.S1);

            // Action
            var result = m.Permit(TestTrigger.T0, TestState.S0, TestState.S1);

            //Assert
            Assert.IsFalse(result);
        }
        
        
        [TestMethod]
        public void PermitTest_AddAlmostDuplicatePermission()
        {
            
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);
            m.Permit(TestTrigger.T0, TestState.S0, TestState.S1);

            // Action
            var result = m.Permit(TestTrigger.T0, TestState.S0, TestState.S2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SubscribeTest_Add()
        {
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);
            var sub = new TestSubscriber();
            // Action
            var ticket = m.Subscribe(sub);
            var result = m.IsSubscriber(sub);
            
            // Assert
            Assert.IsNotNull(ticket);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void SubscribeTest_Add_Remove()
        {
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);
            var sub = new TestSubscriber();
            var ticket = m.Subscribe(sub);
            
            // Action
            ticket.Dispose();
            var result = m.IsSubscriber(sub);
            
            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void TriggerTest_S0toS1withT0()
        {
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);
            m.Permit(TestTrigger.T0, TestState.S0, TestState.S1);
            var sub = new TestSubscriber();
            m.Subscribe(sub);

            // Action
            var result = m.Trigger(TestTrigger.T0);
            
            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(TestState.S1, sub.State);
        }
        
        [TestMethod]
        public void TriggerTest_UnsupportedTransition()
        {
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2);

            // Action
            var result = m.Trigger(TestTrigger.T0);
            
            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void TriggerTest_UnsupportedTransition_RaiseException()
        {
            // Setup 
            var m = new EzStateMachine<TestTrigger, TestState>(TestState.S0, TestState.S2, true);
            
            // Assert
            Assert.ThrowsException<Exception>(() => { m.Trigger(TestTrigger.T0);});
        }

        private class TestSubscriber : IObserver<TestState>
        {
            public TestState State = TestState.Null; 
            public void OnCompleted()
            {
                throw new Exception();
            }

            public void OnError(Exception error)
            {
                throw new Exception();
            }

            public void OnNext(TestState value)
            {
                State = value;
            }
        }
    }
}