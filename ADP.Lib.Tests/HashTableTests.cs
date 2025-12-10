using ADP.Lib.Hashing;

namespace ADP.Lib.Tests;

public class HashTableTests
{
    /// <summary>
    /// This is here to prove that DJB2 hash function provides collisions very easily (for us at least)
    /// According to https://mojoauth.com/hashing/bernsteins-hash-djb2-in-go/ it apparently shouldn't
    /// Provide so many collisions, for now this is nice since we need to implement some solutions to collisions anyway.
    /// </summary>
    [Fact]
    public void ShouldCollide()
    {
        int[] values = new int[] { 12843, 50922 };

        SimpleHashTable<string, string> list = new SimpleHashTable<string, string>();

        Assert.Throws<Exception>(() =>
        {
            list.Add(12843.ToString(), 1.ToString());
            list.Add(50922.ToString(), 2.ToString());
        });
    }
}
