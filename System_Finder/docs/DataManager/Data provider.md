
# DataProvider
Provides data in format based on input string.

- For example:
>  **input**: "Processor of this pc is: **{cpuName}** @**{cpuClock=Ghz}** GHz [**{cpuCores}** C/**{cpuThreads}** T]"
>  
>  **output**: "Processor of this pc is: **AMD FX-8320** @**3,5**GHz [**8** C/**8**T]"


## Input string variables:

> **For CPU:**

| Variables          | Description                                      |
|--------------------|--------------------------------------------------|
| **{cpuName}**      | Represents cpu name                              |
| **{cpuCores}**     | Represents number of cpu cores                   |
| **{cpuThreads}**   | Represents number of cpu threads                 |
| **{cpuClock}**     | Represents cpu clock (by default in GHz)         |
| **{cpuClock=Mhz}** | Represents cpu clock in MHz                      |
| **{cpuClock=Ghz}** | Represents cpu clock in GHz (same as {cpuClock}) |

<br/>

> **For GPU:**

| Variables          | Description         |
|--------------------|---------------------|
| **{gpuName}**      | Represents gpu name |

<br/>

> **For RAM:**

| Variable             | Description                                           |
|----------------------|-------------------------------------------------------|
| **{ramName}**        | Represents RAM name                                   |
| **{ramType}**        | Represents RAM type [DDR]                             |
| **{ramCapacity}**    | Represents RAM capacity (by default in GB)            |
| **{ramCapacity=MB}** | Represents RAM capacity in MB                         |
| **{ramCapacity=GB}** | Represents RAM capacity in GB (same as {ramCapacity}) |
| **{ramClock}**       | Represents RAM clock (by default in GHz)              |
| **{ramClock=Mhz}**   | Represents RAM clock in MHz (same as {ramClock})      |
| **{ramClock=Ghz}**   | Represents RAM clock in GHz                           |

<br/>

> **For HDD:**

| Variable             | Description         |
|----------------------|---------------------|
| **{hddName}**        | Represents HDD name |

<br/>

> **For motherboard:**

| Variable              | Description                 |
|-----------------------|-----------------------------|
| **{motherboardName}** | Represents motherboard name |

<br/>

> **For environment:**

| Variable              | Description                      |
|-----------------------|----------------------------------|
| **{userName}**        | Represents current user          |
| **{operationSystem}** | Represents operation system name |

<br/>

