import React from "react";
import socketIOClient from "socket.io-client";

import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

import useStyles from "./RessourceUsage.styles";
import { RESSOURCE_USAGE_ENDPOINT } from "../../util/socketEndpoints";

function RessourceUsage() {
  const [serverContainers, setServerContainers] = React.useState(null);

  const socketEndpoint = "http://127.0.0.1:5000";

  React.useEffect(() => {
    const socket = socketIOClient(socketEndpoint);
    socket.on(RESSOURCE_USAGE_ENDPOINT, data => {
      const servername = data.servername;
      const containers = data.containers;
      setServerContainers({
        ...serverContainers,
        [servername]: [...containers]
      });
    });
  }, []);

  const styleClasses = useStyles();

  return serverContainers == null ? null : (
    <React.Fragment>
      {Object.keys(serverContainers).map(servername => (
        <div style={{ marginBottom: "18px" }} key={servername}>
          <Typography variant="h6" id="serverName">
            {servername}
          </Typography>
          <TableContainer component={Paper}>
            <Table className={styleClasses.table} aria-label="containers">
              <TableHead>
                <TableRow>
                  <TableCell>Name</TableCell>
                  <TableCell align="right">Id</TableCell>
                  <TableCell align="right">CPU %</TableCell>
                  <TableCell align="right">Memory %</TableCell>
                  <TableCell align="right">Net I/O</TableCell>
                  <TableCell align="right">Disk I/O</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {serverContainers[servername].map(container => (
                  <TableRow key={container.id}>
                    <TableCell component="th" scope="row">
                      {container.name}
                    </TableCell>
                    <TableCell align="right">{container.id}</TableCell>
                    <TableCell align="right">{container.image}</TableCell>
                    <TableCell align="right">
                      {container.state.status}
                    </TableCell>
                    <TableCell align="right">
                      {container.creation_time}
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </div>
      ))}
    </React.Fragment>
  );
}

export default RessourceUsage;
