// DO NOT EDIT: GENERATED BY FloatPackerTestGenerator.cs

using System;
using System.Collections;
using Mirage.Serialization;
using Mirage.Tests.Runtime.ClientServer;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Mirage.Tests.Runtime.Generated.FloatPackAttributeTests
{
    public class FloatPackerBehaviour_100_10 : NetworkBehaviour
    {
        [FloatPack(100, 0.2f)]
        [SyncVar] public float myValue;
    }
    public class FloatPackerTest_100_10 : ClientServerSetup<FloatPackerBehaviour_100_10>
    {
        const float value = 5.2f;
        const float within = 0.196f;

        [Test]
        public void SyncVarIsBitPacked()
        {
            serverComponent.myValue = value;

            using (PooledNetworkWriter writer = NetworkWriterPool.GetWriter())
            {
                serverComponent.SerializeSyncVars(writer, true);

                Assert.That(writer.BitPosition, Is.EqualTo(10));

                using (PooledNetworkReader reader = NetworkReaderPool.GetReader(writer.ToArraySegment()))
                {
                    clientComponent.DeserializeSyncVars(reader, true);
                    Assert.That(reader.BitPosition, Is.EqualTo(10));

                    Assert.That(clientComponent.myValue, Is.EqualTo(value).Within(within));
                }
            }
        }
    }
}
