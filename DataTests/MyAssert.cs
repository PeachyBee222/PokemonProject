using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;
using System.Collections.Specialized;

namespace PokemonProjectPokemonProject.DataTests
{
    /// <summary>
    /// The collection changed class used for test cases
    /// </summary>
    internal static class MyAssert
    {
        /// <summary>
        /// The exception for an event not being changed
        /// </summary>
        public class NotifyCollectionChangedNotTriggeredException : XunitException
        {
            public NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction expectedAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw none.") { }
        }
        /// <summary>
        /// The exception for the event being the incorrect action
        /// </summary>
        public class NotifyCollectionChangedWrongActionException : XunitException
        {
            public NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction expectedAction, NotifyCollectionChangedAction actualAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw {actualAction}") { }
        }
        /// <summary>
        /// The exception for the event being an add event changing
        /// </summary>
        public class NotifyCollectionChangedAddException : XunitException
        {
            public NotifyCollectionChangedAddException(object expected, object actual) : base($"Expected a NotifyCollectionChanged event with an action of Add and object {expected} but instead saw {actual}") { }
        }

        /// <summary>
        /// The exception for the event being a remove event changing
        /// </summary>
        public class NotifyCollectionChangedRemoveException : XunitException
        {
            public NotifyCollectionChangedRemoveException(object expectedItem, object actualItem) : base($"Expected a NotifyCollectionChanged event with an action of Remove and object {expectedItem} but instead saw {actualItem}") { }


        }
        /// <summary>
        /// The class to check of there is a collection change from adding an item
        /// </summary>
        /// <typeparam name="T">the type of the item we are looking at adding</typeparam>
        /// <param name="collection">the collection the item is added to</param>
        /// <param name="newItem">the item we are adding</param>
        /// <param name="testCode">the test to see if adding works</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException">if this is not an add action but a different action throw this exception</exception>
        /// <exception cref="NotifyCollectionChangedAddException">exception if the add event changes</exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException">exception for event not being changed</exception>
        public static void NotifyCollectionChangedAdd<T>(INotifyCollectionChanged collection, T newItem, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Add event
                if (args.Action != NotifyCollectionChangedAction.Add)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Add, args.Action);
                }

                // Make sure we added just one item
                if (args.NewItems?.Count != 1)
                {
                    // We'll use the collection of added items as the second argument
                    throw new NotifyCollectionChangedAddException(newItem, args.NewItems);
                }

                // Make sure the added item is what we expected
                if (!args.NewItems[0].Equals(newItem))
                {
                    // Here we only have one item in the changed collection, so we'll report it directly
                    throw new NotifyCollectionChangedAddException(newItem, args.NewItems[0]);
                }

                // If we reach this point, the NotifyCollectionChanged event was triggered successfully
                // and contains the correct item! We'll set the flag to true so we know.
                notifySucceeded = true;
            };

            // Now we connect the event handler 
            collection.CollectionChanged += handler;

            // And attempt to trigger the event by running the actionCode
            // We place this in a try/catch to be able to utilize the finally 
            // clause, but don't actually catch any exceptions
            try
            {
                testCode();
                // After this code has been run, our handler should have 
                // triggered, and if all went well, the notifySucceed is true
                if (!notifySucceeded)
                {
                    // If notifySucceed is false, the event was not triggered
                    // We throw an exception denoting that
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Add);
                }
            }
            // We don't actually want to catch an exception - we want it to 
            // bubble up and be reported as a failing test.  So we don't 
            // have a catch () {} clause to this try/catch.
            finally
            {
                // However, we *do* want to remove the event handler. We do 
                // this in a finally block so it will happen even if we do 
                // have an exception occur. 
                collection.CollectionChanged -= handler;
            }
        }
        /// <summary>
        /// The class to check if a collection change is happening from removing an item
        /// </summary>
        /// <typeparam name="T">the type of the item being removed</typeparam>
        /// <param name="collection">the collection the item is removed from</param>
        /// <param name="oldItem">the item removed</param>
        /// <param name="testCode">the test for the item being removed</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException">if the item was not removed but a different action occured</exception>
        /// <exception cref="NotifyCollectionChangedRemoveException">the exception of the removed item being changed</exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException">the excpetion if the action is not being triggered</exception>
        public static void NotifyCollectionChangedRemove<T>(INotifyCollectionChanged collection, T oldItem, Action testCode) //fixme, is this class correct?
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Remove event
                if (args.Action != NotifyCollectionChangedAction.Remove)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Remove, args.Action);
                }

                // Make sure we removed just one item
                if (args.OldItems?.Count != 1)
                {
                    // We'll use the collection of removed items as the second argument
                    throw new NotifyCollectionChangedRemoveException(oldItem, args.OldItems[0]);
                }

                // Make sure the removed item is what we expected
                if (!args.OldItems[0].Equals(oldItem))
                {
                    // Here we only have one item in the changed collection, so we'll report it directly
                    throw new NotifyCollectionChangedRemoveException(oldItem, args.OldItems[0]);
                }

                // If we reach this point, the NotifyCollectionChanged event was triggered successfully
                // and contains the correct item! We'll set the flag to true so we know.
                notifySucceeded = true;
            };

            // Now we connect the event handler 
            collection.CollectionChanged += handler;

            // And attempt to trigger the event by running the actionCode
            // We place this in a try/catch to be able to utilize the finally 
            // clause, but don't actually catch any exceptions
            try
            {
                testCode();
                // After this code has been run, our handler should have 
                // triggered, and if all went well, the notifySucceed is true
                if (!notifySucceeded)
                {
                    // If notifySucceed is false, the event was not triggered
                    // We throw an exception denoting that
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Remove);
                }
            }
            // We don't actually want to catch an exception - we want it to 
            // bubble up and be reported as a failing test.  So we don't 
            // have a catch () {} clause to this try/catch.
            finally
            {
                // However, we *do* want to remove the event handler. We do 
                // this in a finally block so it will happen even if we do 
                // have an exception occur. 
                collection.CollectionChanged -= handler;
            }
        }
    }
}
