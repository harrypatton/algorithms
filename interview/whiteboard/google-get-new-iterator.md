source: http://www.1point3acres.com/bbs/forum.php?mod=viewthread&tid=259568&extra=page%3D1%26filter%3Dauthor%26orderby%3Ddateline%26sortid%3D311%26sortid%3D311%26orderby%3Ddateline

给一个返回值依次为[A, C, C, C, D, D]的iterator, 要求返回另一个iterator, 这个新的iterator要能依次输出如下结果
[(A, 1), (C, 3), (D, 2)].

**Update**: it is a little bit tricky to handle edge cases; the first letter and the last one. Here's what I get,

```csharp

        static IEnumerable<string> GetNewIterator(IEnumerator<char> iterator) {
            int count = 0;
            char c = 'a';

            while (iterator.MoveNext()) {
                if (iterator.Current == c) {
                    count++;
                } else {
                    if (count > 0) {
                        yield return $"{c.ToString()}{count}";
                    }

                    count = 1;
                    c = iterator.Current;
                }
            }

            yield return count > 0 ? $"{c.ToString()}{count}" : null;
        }

```
