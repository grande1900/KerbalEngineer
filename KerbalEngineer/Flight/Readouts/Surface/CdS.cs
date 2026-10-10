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
using KerbalEngineer.Flight.Sections;
using System;

#endregion

namespace KerbalEngineer.Flight.Readouts.Surface
{
	public class CdS: ReadoutModule
	{
		#region Constructors

		public CdS()
		{
			this.Name = "CdS";
			this.ShortName = "CdS";
			this.Category = ReadoutCategory.GetCategory( "Surface" );
			this.HelpString = "Shows the vessel's CdS.";
			this.IsDefault = true;
		}

		#endregion

		#region Methods: public

		public override void Draw( Unity.Flight.ISectionModule section )
		{
			if ( AtmosphericProcessor.ShowDetails )
			{
				var drag = Vector3d.Dot( AtmosphericProcessor.Lift + AtmosphericProcessor.Drag, -FlightGlobals.ActiveVessel.srf_vel_direction );
				this.DrawLine( ( drag / FlightGlobals.ActiveVessel.dynamicPressurekPa ).ToString( "N3" ) + "m²", section );
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