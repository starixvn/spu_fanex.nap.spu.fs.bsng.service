namespace Fanex.NAP.SPU.FS.BSNG.Tests.Shares
{
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using FluentAssertions;
    using Xunit;

    public class UtilitiesTests
    {
        [Theory]
        [InlineData(5, 2)]
        [InlineData(6, 2)]
        [InlineData(1, 1)]
        public void Chunk_Should_Split_Into_Expected_Buckets(int total, int chunkSize)
        {
            var input = Enumerable.Range(1, total).ToList();

            var chunks = Utilities.Chunk(input, chunkSize).Select(c => c.ToList()).ToList();

            chunks.Should().NotBeNull();
            chunks.Should().NotBeEmpty();

            // Validate sizes
            for (int i = 0; i < chunks.Count; i++)
            {
                if (i < chunks.Count - 1)
                {
                    chunks[i].Count.Should().Be(chunkSize);
                }
                else
                {
                    chunks[i].Count.Should().BeLessOrEqualTo(chunkSize);
                }
            }

            // Validate that flattening equals original
            chunks.SelectMany(x => x).Should().BeEquivalentTo(input);
        }

        [Fact]
        public void Chunk_With_Empty_Source_Should_Return_One_Empty_Chunk()
        {
            var input = new List<int>();

            var chunks = Utilities.Chunk(input, 3).ToList();

            chunks.Should().HaveCount(1);
            chunks[0].Should().BeEmpty();
        }

        [Theory]
        [InlineData(5, 2)]
        [InlineData(6, 2)]
        [InlineData(1, 1)]
        public void Chunk2_Should_Split_Into_Expected_Buckets(int total, int chunkSize)
        {
            var input = Enumerable.Range(1, total).ToList();

            var chunks = input.Chunk2(chunkSize).Select(c => c.ToList()).ToList();

            chunks.Should().NotBeNull();

            for (int i = 0; i < chunks.Count; i++)
            {
                if (i < chunks.Count - 1)
                {
                    chunks[i].Count.Should().Be(chunkSize);
                }
                else
                {
                    chunks[i].Count.Should().BeLessOrEqualTo(chunkSize);
                }
            }

            chunks.SelectMany(x => x).Should().BeEquivalentTo(input);
        }

        [Fact]
        public void Chunk2_With_Empty_Source_Should_Return_Empty()
        {
            var input = new List<int>();

            var chunks = input.Chunk2(3).ToList();

            chunks.Should().BeEmpty();
        }
    }
}


