﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    static class Loader
    {
        public static uint ReadUint(this Stream fs)
        {
            uint result = 0;

            char c = '0';
            do
            {
                result = result * 10 + (uint)(c - '0');

                c = (char)fs.ReadByte();

            } while (fs.CanRead && c != '\n' && c != ' ');

            return result;
        }

        public static void Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Parameters of the simulation
                uint rows = stream.ReadUint();
                uint columns = stream.ReadUint();
                uint drones = stream.ReadUint();
                uint deadline = stream.ReadUint();
                uint droneMaxLoad = stream.ReadUint();

                Simulation.Rows = rows;
                Simulation.Columns = columns;
                Simulation.Deadline = deadline;
                Simulation.DroneMaxLoad = droneMaxLoad;

                // Spawn drones
                for (uint i = 0; i < drones; i++)
                {
                    // TODO: creae empty drone at [0;0]
                }

                // Products weights
                uint productTypesCount = stream.ReadUint();
                uint[] productTypesWeights = new uint[productTypesCount];
                for (uint i = 0; i < productTypesCount; i++)
                {
                    productTypesWeights[i] = stream.ReadUint();
                }

                // Warehouses
                uint wareHousesCount = stream.ReadUint();
                for (uint i = 0; i < wareHousesCount; i++)
                {
                    uint wRow = stream.ReadUint();
                    uint wColumn = stream.ReadUint();

                    Warehouse w = new Warehouse((int)wRow, (int)wColumn, (int)productTypesCount);

                    uint[] wItemsCount = new uint[productTypesCount];
                    for (uint j = 0; j < productTypesCount; j++)
                    {
                        uint count = stream.ReadUint();
                        if (count > 0)
                        {
                            // TODO: add to the warehouse product with id=j and amount=count, weight take from productTypesWeights[j]
                        }
                    }
                    
                    Simulation.Warehouses.Add(w);
                }

                // Customers Orders
                uint ordersCount = stream.ReadUint();
                for (uint i = 0; i < ordersCount; i++)
                {
                    uint deliveryRow = stream.ReadUint();
                    uint deliveryColumn = stream.ReadUint();

                    uint orderedProductsCount = stream.ReadUint();
                    for (uint j = 0; j < orderedProductsCount; j++)
                    {
                        uint productID = stream.ReadUint();
                       
                    }
                }
            }
        }
    }
}
