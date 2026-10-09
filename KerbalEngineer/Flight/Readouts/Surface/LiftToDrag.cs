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
using KerbalEngineer.Flight.Readouts.Vessel;
using KerbalEngineer.Flight.Sections;
using System;


#endregion

namespace KerbalEngineer.Flight.Readouts.Surface
{
	public class LiftToDrag: ReadoutModule
	{
		#region Constructors

		public LiftToDrag()
		{
			this.Name = "Lift to Drag ratio";
			this.ShortName = "LDR";
			this.Category = ReadoutCategory.GetCategory( "Surface" );
			this.HelpString = "Shows the vessel's current Lift/Drag ratio.";
			this.IsDefault = true;
		}

		#endregion

		#region Methods: public

		public override void Draw( Unity.Flight.ISectionModule section )
		{
			if ( AtmosphericProcessor.ShowDetails )
			{
				var lift = Vector3d.Dot( AtmosphericProcessor.Lift, FlightGlobals.ActiveVessel.srf_vel_direction );
				var drag = Vector3d.Dot( AtmosphericProcessor.Drag, FlightGlobals.ActiveVessel.srf_vel_direction );
				this.DrawLine( ( lift / drag ).ToString( "F2" ), section );
			}
		}

		public override void Reset()
		{
			FlightEngineerCore.Instance.AddUpdatable( AtmosphericProcessor.Instance );
		}

		public override void Update()
		{
			AtmosphericProcessor.RequestUpdate();
		}
		#endregion
	}
}