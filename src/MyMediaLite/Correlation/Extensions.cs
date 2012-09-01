// Copyright (C) 2012 Zeno Gantner
// 
// This file is part of MyMediaLite.
// 
// MyMediaLite is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// MyMediaLite is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with MyMediaLite.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using System.Collections.Generic;

namespace MyMediaLite.Correlation
{
	/// <summary>Extension methods for correlation matrices</summary>
	public static class Extensions
	{
		/// <summary>Sum up the correlations between a given entity and the entities in a collection</summary>
		/// <param name="correlation">the correlation matrix</param>
		/// <param name="entity_id">the numerical ID of the entity</param>
		/// <param name="entities">a collection containing the numerical IDs of the entities to compare to</param>
		/// <param name="q">score exponent</param>
		/// <returns>the correlation sum</returns>
		public static double SumUp(this ICorrelationMatrix correlation, int entity_id, ICollection<int> entities, float q = 1.0f)
		{
			int num_entities = correlation.NumEntities;
			
			if (entity_id < 0 || entity_id >= num_entities)
				throw new ArgumentException("Invalid entity ID: " + entity_id);

			double result = 0;
			foreach (int entity_id2 in entities)
				//if (entity_id2 < num_entities)
					result += Math.Pow(correlation[entity_id, entity_id2], q);
			return result;
		}

	}
}

