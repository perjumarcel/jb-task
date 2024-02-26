# Running the application

## Running the frontend

From the `frontend` folder run the command `npm install` to install all the necessary packages. Then run the command `npm run start` to start the fronend app.

## Running the backend

From `backend` folder open the solution file `RealTimeApp.sln`. Build the solution and run `RealTimeApp` project.


## Assumptions and ideas

For scalability it was considered that it may be beneficial to make the initial setup being able to fetch/stream the data from different data sources for specific symbols. Like for currencies from one data source(Forex) and for stocks from another. The implementation is just a switch with some conditions, but it may be easily extended based on future requirements.

Was considered that it would be beneficial to stop fetching data unnecesarely for symbols which has no subscribers to minimize the costs and resource usages.

For performance on real-data display, was considered utilization of `React.memo()`, `useCallback` and other mechanisms to minimize unnecessary re-renderings.

Another consideration was using some kind of viewport virtualization(like `react-virtualized`) which should improve perfomance by reducing the number of DOM elements necessary to be created/managed. This would be usefull when working with multiple symbol subscription(long list). As there was a time restriction(which already was exceeded :)) this was left out from implementation.

NOTE: due to the fact that the time restriction was exceeded, tests was added partially for the backed side only.