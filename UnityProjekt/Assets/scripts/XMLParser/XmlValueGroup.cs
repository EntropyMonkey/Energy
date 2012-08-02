using System;
using System.Collections.Generic;

namespace XMLParser
{
	public class ValueGroup
	{
		protected Dictionary<string, double> properties;
		
		protected Dictionary<string, double> active;
		protected Dictionary<string, double> passive;
		protected Dictionary<string, double> construct;
		
		public int ConstructTime;
		
		public ValueGroup ()
		{
			properties = new Dictionary<string, double>();
			
			active = new Dictionary<string, double>();
			passive = new Dictionary<string, double>();
			construct = new Dictionary<string, double>();
		}
		
		public void addProperty (string inKey, double inValue)
		{
			addValue(properties, inKey, inValue);
		}
		
		public double getProperty (string inKey)
		{
			return getValue(properties, inKey);
		}
		
		public void addActive (string inKey, double inValue)
		{
			addValue(active, inKey, inValue);
		}
		
		public double getActive (string inKey)
		{
			return getValue(active, inKey);
		}
		
		public void addPassive (string inKey, double inValue)
		{
			addValue(passive, inKey, inValue);
		}
		
		public double getPassive (string inKey)
		{
			return getValue(passive, inKey);
		}
		
		public void addConstruct (string inKey, double inValue)
		{
			addValue(construct, inKey, inValue);
		}
		
		public double getConstruct (string inKey)
		{
			return getValue(construct, inKey);
		}
		
		protected void addValue (Dictionary<string, double> inDict, string inKey, double inValue)
		{
			inKey = inKey.ToLower();
			if (inDict.ContainsKey(inKey))
			{
				inDict[inKey] += inValue;
			}
			else
			{
				inDict.Add(inKey, inValue);
			}
		}
		
		protected double getValue (Dictionary<string, double> inDict, string inKey)
		{
			inKey = inKey.ToLower();
			if (inDict.ContainsKey(inKey))
			{
				return inDict[inKey];
			}
			
			return 0;
		}
	}
}

