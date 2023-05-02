using System;
namespace GraphVersionOne
{
    // Enumeration types for tube Staion access & status

    //code referenced from Week1 tutorial solution

    interface AccessStatus
    {
        enum ACCESS { Stairs, Lift, Escalator };    // Station Accesses

        enum STATUS { Open, Closed };               // Station Status

    }
}

