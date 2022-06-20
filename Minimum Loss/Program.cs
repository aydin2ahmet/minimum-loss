var result = minimumLoss(new List<long>() { 20, 3,9, 13,8 });

Console.WriteLine(result);

int minimumLoss(List<long> price)
{
    var sortedPrice = price.Select((x, i) => new KeyValuePair<long, int>(x, i)).OrderBy(x => x.Key).ToList();

    List<long> priceSorted = sortedPrice.Select(x => x.Key).ToList();
    List<int> priceIndex = sortedPrice.Select(x => x.Value).ToList();

    var distance = new List<long>();

    for (int i = 0; i < priceSorted.Count() - 1; i++)
        distance.Add(priceSorted[i + 1] - priceSorted[i]);

    var sortedDistance = distance.Select((x, i) => new KeyValuePair<long, int>(x, i)).OrderBy(x => x.Key).ToList();

    List<long> distanceSorted = sortedDistance.Select(x => x.Key).ToList();
    List<int> distanceIndex = sortedDistance.Select(x => x.Value).ToList();

    for (int i = 0; i < distanceSorted.Count(); i++)
    {
        var index = distanceIndex[i];

        if (priceIndex[index + 1] < priceIndex[index])
            return (int)distanceSorted[i];
    }

    return 1;
}