using System;

using UnityEngine;

using Object = UnityEngine.Object;

namespace BLASTER_RIVALS.DesignPatterns
{
	public abstract class Factory<TYPE, F_TYPE> where TYPE : Object where F_TYPE : Factory<TYPE, F_TYPE>, new()
	{
		private static F_TYPE instance;

		protected TYPE factoryItem;

		public static void Init(TYPE _item, params object[] _params)
		{
			if(instance != null)
			{
				Debug.LogWarning("Factory already setup! Ignoring init call...");
				return;
			}

			instance = new F_TYPE
			{
				factoryItem = _item
			};

			instance.OnInit(_params);
		}

		public static TYPE Create(params object[] _params)
		{
			if(instance != null)
				return instance.GenerateItem(_params);

			throw new InvalidOperationException($"Factory {typeof(F_TYPE).Name} not setup!");
		}

		protected abstract TYPE GenerateItem(params object[] _params);

		protected virtual void OnInit(params object[] _params) { }
	}
}