using System;

public class SnowflakeIdGenerator
{
    private const long Twepoch = 1288834974657L; // (January 1, 1970, UTC).
    private const int TimestampBits = 41;
    private const int MachineIdBits = 10;
    private const int SequenceBits = 12;

    private const long MaxMachineId = -1L ^ (-1L << MachineIdBits);
    private const long MaxSequence = -1L ^ (-1L << SequenceBits);

    private readonly long _machineId;
    private long _lastTimestamp = -1L;
    private long _sequence = 0L;

    private readonly object _lock = new object();

    public SnowflakeIdGenerator(long machineId)
    {
        if (machineId < 0 || machineId > MaxMachineId)
        {
            throw new ArgumentOutOfRangeException(nameof(machineId), $"Machine ID must be between 0 and {MaxMachineId}");
        }

        _machineId = machineId;
    }

    public long GenerateId()
    {
        lock (_lock)
        {
            long timestamp = GetTimestamp();

            if (timestamp < _lastTimestamp)
            {
                throw new InvalidOperationException($"Clock moved backwards. Refusing to generate ID for {_lastTimestamp - timestamp} milliseconds.");
            }

            if (_lastTimestamp == timestamp)
            {
                _sequence = (_sequence + 1) & MaxSequence;

                if (_sequence == 0)
                {
                    timestamp = WaitNextMillis(_lastTimestamp);
                }
            }
            else
            {
                _sequence = 0L;
            }

            _lastTimestamp = timestamp;

            return ((timestamp - Twepoch) << (MachineIdBits + SequenceBits))
                 | (_machineId << SequenceBits)
                 | _sequence;
        }
    }

    private static long GetTimestamp() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private static long WaitNextMillis(long lastTimestamp)
    {
        long timestamp = GetTimestamp();
        while (timestamp <= lastTimestamp)
        {
            timestamp = GetTimestamp();
        }
        return timestamp;
    }
}
