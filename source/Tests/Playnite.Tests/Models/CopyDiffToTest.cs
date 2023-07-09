using NUnit.Framework;
using NUnit.Framework.Internal;
using Playnite.Common;
using Playnite.SDK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Playnite.Tests.Models
{
    [TestFixture]
    public class CopyDiffToTests
    {
        [Test]
        public void GameCopyDiffToTest()
        {
            var random = new Random();
            var generated = GenerateObject<Game>(random, false);
            var generated2 = GenerateObject<Game>(random, true);
            generated2.Id = generated.Id;
            var empty = new Game() { Id = generated.Id };
            generated.CopyDiffTo(empty);
            generated.CopyDiffTo(generated2);

            Assert.AreEqual(0, generated.GetDifferences(empty).Count);
            Assert.AreEqual(0, generated.GetDifferences(generated2).Count);
            Assert.AreEqual(Serialization.ToJson(generated), Serialization.ToJson(empty));
            Assert.AreEqual(Serialization.ToJson(generated), Serialization.ToJson(generated2));

            generated2.Name = "test";
            generated2.Description = "test2";
            var changes = 0;
            generated2.PropertyChanged += (_, __) => changes++;
            generated.CopyDiffTo(generated2);
            Assert.AreEqual(2, changes);
        }

        public void CopyDiffToTest<T>() where T : DatabaseObject
        {
            var random = new Random();
            var generated = GenerateObject<T>(random, false);
            var generated2 = GenerateObject<T>(random, true);
            generated2.Id = generated.Id;
            var empty = typeof(T).CrateInstance<T>();
            empty.Id = generated.Id;
            generated.CopyDiffTo(empty);
            generated.CopyDiffTo(generated2);

            Assert.AreEqual(Serialization.ToJson(generated), Serialization.ToJson(empty));
            Assert.AreEqual(Serialization.ToJson(generated), Serialization.ToJson(generated2));
        }
    }
}
