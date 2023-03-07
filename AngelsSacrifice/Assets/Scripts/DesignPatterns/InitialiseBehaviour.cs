using UnityEngine;

namespace BLASTER_RIVALS.DesignPatterns
{
	public abstract class InitialiseBehaviour : MonoBehaviour, IInitialiser
	{
		public bool Initialised { get; private set; }
		
		/// <summary> Initialises an object if it isn't already. Can take in any number and any type of parameters. </summary>
		/// <param name="_params"> A variable amount and type of parameters for complete dynamic initialisation. </param>
		public void Initialise(params object[] _params)
		{
			// Make sure the object hasn't already been initialised. If it has, warn and return.
			if(Initialised)
			{
				Debug.LogWarning($"Object {name} has already been initialised!", gameObject);
				return;
			}

			// Mark the object as initialised and call the OnInit function for the inheriting type.
			Initialised = true;
			OnInit(_params);
		}

		protected abstract void OnInit(params object[] _params);
	}
}