// 
//     Kerbal Engineer Redux
// 
//     Copyright (C) 2014 CYBUTEK
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

#region Using Directives

using KerbalEngineer.Extensions;
using KerbalEngineer.Flight.Readouts.Surface;
using KerbalEngineer.Flight.Sections;
using KerbalEngineer.Helpers;
using KerbalEngineer.VesselSimulator;

#endregion

namespace KerbalEngineer.Flight.Readouts.Vessel
{
	public class UpwardsForce: ReadoutModule
	{
		#region Fields

		private Vector3d gravity;

		#endregion

		#region Constructors

		public UpwardsForce()
		{
			this.Name = "Upwards Lift Force";
			this.Category = ReadoutCategory.GetCategory( "Surface" );
			this.HelpString = "The current total upwards lift force of the vessel.";
			this.IsDefault = false;
		}

		#endregion

		#region Methods: public

		public override void Draw( Unity.Flight.ISectionModule section )
		{
			if ( SimulationProcessor.ShowDetails )
			{
				var lwr = Vector3d.Dot( AtmosphericProcessor.Lift + AtmosphericProcessor.Drag, FlightGlobals.ActiveVessel.upAxis );
				this.DrawLine( lwr.ToForce( section.IsHud ? HudDecimalPlaces : DecimalPlaces ), section );
			}
		}

		public override void Reset()
		{
			FlightEngineerCore.Instance.AddUpdatable( SimulationProcessor.Instance );
		}

		public override void Update()
		{
			SimulationProcessor.RequestUpdate();
		}

		#endregion
	}
}