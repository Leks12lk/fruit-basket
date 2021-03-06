// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using FruitBasket.Core;
using FruitBasket.Core.Models;
using FruitBasket.Core.ServicesInterfaces;
using FruitBasket.Core.Services;

namespace FruitBasket.Web.DependencyResolution {
	using StructureMap;
	using Core.Interfaces;
	using Interfaces;
	using Mappers;

	public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
			For<IGuessingService>().Use<GuessingService>();
	        For<IViewModelsMapper>().Use<ViewModelsMapper>();
	        For<IGuessing>().Use<GuessingForRandomPlayer>().Named(PlayerType.Random.ToString());
	        For<IGuessing>().Use<GuessingForMemoryPlayer>().Named(PlayerType.Memory.ToString());
	        For<IGuessing>().Use<GuessingForThoroughPlayer>().Named(PlayerType.Thorough.ToString());
	        For<IGuessing>().Use<GuessingForCheaterPlayer>().Named(PlayerType.Cheater.ToString());
	        For<IGuessing>().Use<GuessingForThoroughCheaterPlayer>().Named(PlayerType.ThoroughCheater.ToString());
		}

        #endregion
    }
}